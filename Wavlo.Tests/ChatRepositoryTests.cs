    using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using Wavlo.Data;
    using Wavlo.Models;
    using Wavlo.Repository;

    namespace Wavlo.Tests
    {
        public class ChatRepositoryTests
        {
        private ChatDbContext GetDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<ChatDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new ChatDbContext(options);
        }

        [Fact]
        public async Task CreatePrivateRoomAsync_ShouldCreateRoom_WhenNotExists()
        {
            // Arrange
            var context = GetDbContext(Guid.NewGuid().ToString());

            var user1 = new User { Id = "user1", FirstName = "Ahmed", LastName = "Ali" };
            var user2 = new User { Id = "user2", FirstName = "Sara", LastName = "Mohamed" };

            context.Users.AddRange(user1, user2);
            await context.SaveChangesAsync();

            var repo = new ChatRepository(context);

            // Act
            var chatId = await repo.CreatePrivateRoomAsync("user1", "user2");

            // Assert
            var chat = await context.Chats.Include(c => c.Users).FirstOrDefaultAsync(c => c.Id == chatId);
            Assert.NotNull(chat);
            Assert.Equal(ChatType.Private, chat.Type);
            Assert.Contains(chat.Users, u => u.UserId == "user1");
            Assert.Contains(chat.Users, u => u.UserId == "user2");
        }

        [Fact]
        public async Task CreateMessageAsync_ShouldAddMessage()
        {
            // Arrange
            var context = GetDbContext(Guid.NewGuid().ToString());
            var repository = new ChatRepository(context);

            var user = new User { Id = "user1", FirstName = "Test", LastName = "User" };
            var chat = new Chat { Id = 1, IsGroup = false };

            context.Users.Add(user);
            context.Chats.Add(chat);
            await context.SaveChangesAsync();

            var message = new Message
            {
                ChatId = chat.Id,
                UserId = user.Id,
                Content = "Hello!",
                SentAt = DateTime.UtcNow
            };

            // Act
            await repository.CreateMessageAsync(
                chat.Id,
                "Hello!",
                user.Id,
                null,         
                null         
            );


            // Assert
            var messages = context.Messages.ToList();
            Assert.Single(messages);
            Assert.Equal("Hello!", messages[0].Content);
            Assert.Equal(user.Id, messages[0].UserId);
        }

        [Fact]
        public async Task EditMessageAsync_ShouldUpdateMessageContentAndAttachment()
        {
            var context = GetDbContext(Guid.NewGuid().ToString());

            var message = new Message
            {
                Id = 1,
                ChatId = 1,
                UserId = "user1",
                Name = "Sender Name", 
                Content = "Original message",
                SentAt = DateTime.UtcNow
            };

            context.Messages.Add(message);
            await context.SaveChangesAsync();

            var repo = new ChatRepository(context);
            var result = await repo.EditMessageAsync(1, "New Content", "newAttachment.png");

            var updatedMessage = await context.Messages.FindAsync(1);
            Assert.True(result);
            Assert.Equal("New Content", updatedMessage.Content);
            Assert.Equal("newAttachment.png", updatedMessage.AttachmentUrl);
        }
        [Fact]
        public async Task DeleteMessageAsync_ShouldRemoveMessage()
        {
            var context = GetDbContext(Guid.NewGuid().ToString());
            var message = new Message 
            {
                Id = 1,
                ChatId = 1,
                UserId = "user1",
                Name = "Test User", 
                Content = "Message to delete",
                SentAt = DateTime.UtcNow
            };
            context.Messages.Add(message);
            await context.SaveChangesAsync();

            var repo = new ChatRepository(context);
            var result = await repo.DeleteMessageAsync(1);

            var exists = await context.Messages.FindAsync(1);
            Assert.True(result);
            Assert.Null(exists);
        }
        [Fact]
        public async Task CreateRoomAsync_ShouldCreateGroupChat()
        {
            var context = GetDbContext(Guid.NewGuid().ToString());

            
            var user = new User
            {
                Id = "user1",
                FirstName = "Ali",
                LastName = "Mohamed"
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();

            var repo = new ChatRepository(context);
            var chatId = await repo.CreateRoomAsync("Test Group", "user1", true);

            var chat = await context.Chats.Include(c => c.Users).FirstOrDefaultAsync(c => c.Id == chatId);

            Assert.NotNull(chat);
            Assert.Equal(ChatType.Group, chat.Type);
            Assert.True(chat.IsGroup);

            var chatUser = chat.Users.FirstOrDefault(u => u.UserId == "user1");
            Assert.NotNull(chatUser);
            Assert.Equal(UserRole.Admin, chatUser.Role);
            Assert.Equal("Ali Mohamed", chatUser.DisplayName); 
        }

        [Fact]
        public async Task JoinRoomAsync_ShouldAddUserToChat()
        {
            var context = GetDbContext(Guid.NewGuid().ToString());
            var user = new User 
            { 
                Id = "user2",
                FirstName = "Ali",
                LastName = "Mohamed"
            };
            var chat = new Chat 
            { 
                Id = 1, 
                Type = ChatType.Group, 
                IsGroup = true 
            };
            context.Users.Add(user);
            context.Chats.Add(chat);
            await context.SaveChangesAsync();

            var repo = new ChatRepository(context);
            var result = await repo.JoinRoomAsync(1, "user2");

            var joined = await context.ChatUsers.FirstOrDefaultAsync(c => c.ChatId == 1 && c.UserId == "user2");
            Assert.True(result);
            Assert.NotNull(joined);
        }
        [Fact]
        public async Task LeaveRoomAsync_ShouldRemoveUserFromChat()
        {
            var context = GetDbContext(Guid.NewGuid().ToString());
            var chatUser = new ChatUser 
            { 
                ChatId = 1, 
                UserId = "user1" , 
                DisplayName = "Ali Mohamed" 
            };
            context.ChatUsers.Add(chatUser);
            await context.SaveChangesAsync();

            var repo = new ChatRepository(context);
            var result = await repo.LeaveRoomAsync(1, "user1");

            var stillThere = await context.ChatUsers.FindAsync(1, "user1");
            Assert.True(result);
            Assert.Null(stillThere);
        }
        [Fact]
        public async Task GetChatAsync_ShouldReturnChatWithMessages()
        {
            var context = GetDbContext(Guid.NewGuid().ToString());
            var chat = new Chat { Id = 1 };
            var message = new Message 
            { 
                Id = 1, 
                Name = "Test",
                ChatId = 1, 
                Content = "Test", 
                UserId = "user1" 
            };
            context.Chats.Add(chat);
            context.Messages.Add(message);
            await context.SaveChangesAsync();

            var repo = new ChatRepository(context);
            var result = await repo.GetChatAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Single(result.Messages);
        }
        [Fact]
        public async Task GetChatsAsync_ShouldReturnChatsForUser()
        {
            var context = GetDbContext(Guid.NewGuid().ToString());
            context.ChatUsers.Add(new ChatUser 
            { 
                ChatId = 1, 
                UserId = "user1",
                DisplayName = "Ali Mohamed"
            });
            context.Chats.Add(new Chat { Id = 1 });
            await context.SaveChangesAsync();

            var repo = new ChatRepository(context);
            var chats = await repo.GetChatsAsync("user1");

            Assert.Single(chats);
        }
        [Fact]
        public async Task GetPrivateChatsAsync_ShouldReturnPrivateChats()
        {
            var context = GetDbContext(Guid.NewGuid().ToString());
            var user = new User
            {
                Id = "user1" ,
                FirstName = "Test",
                LastName = "user",
            };
            var chat = new Chat 
            { 
                Id = 1, 
                Type = ChatType.Private 
            };
            var chatUser = new ChatUser 
            { 
                ChatId = 1, 
                UserId = "user1", 
                User = user,
                DisplayName = "User"
            };

            context.Users.Add(user);
            context.Chats.Add(chat);
            context.ChatUsers.Add(chatUser);
            await context.SaveChangesAsync();

            var repo = new ChatRepository(context);
            var privateChats = await repo.GetPrivateChatsAsync("user1");

            Assert.Single(privateChats);
        }



    }
}
