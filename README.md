# 📱 Wavlo - A Sign Language Powered Chat App  

**Wavlo** is a real-time chat application that delivers a WhatsApp-like experience while breaking communication barriers for the **deaf and mute** community.  
It combines **core chat features** with **AI-based sign language video translation**, enabling inclusive communication like never before.

---

## 🚀 Features  

### ✅ Core Chat Features  
- 💬 Private & group messaging  
- 🎙️ Voice messaging  
- 🎥 Send video messages  
- ✏️ Edit and delete messages  
- 🔔 Real-time messaging via SignalR  
- 📍 Share location *(coming soon)*  
- 😄 Emojis and stickers *(coming soon)*  

### ♿ Accessibility-First Features  
- 👋 **Send sign language video messages**  
- ✨ **Translate sign language video into:**  
  - 📄 Readable **text**  
  - 🔊 **Voice** messages for hearing users  
- 🌐 Currently supports **English Sign Language** *(multi-language support in progress)*  

---

## 🛠️ Tech Stack  

| Layer     | Technology                   |  
|-----------|------------------------------|  
| Backend   | ASP.NET Core                 |  
| Frontend  | Flutter                      |  
| Auth      | JWT + ASP.NET Identity       |  
| Real-time | SignalR                      |  
| Database  | SQL Server                   |  
| Docs      | Scalar (OpenAPI docs)        |  

---

## 📁 Project Structure  

```
Wavlo_Backend/  
├── Wavlo.API/              # API entry point (Controllers, Hubs)  
│   ├── Controllers/  
│   ├── Hubs/  
│   ├── Program.cs  
│   ├── appsettings.json  
│   └── Wavlo.API.csproj  
├── Wavlo.Application/      # Business logic and service interfaces  
│   ├── Interfaces/         # Contains IChatService, IEmailSender...  
│   ├── Services/           # Contains ChatService, EmailService...  
│   └── Wavlo.Application.csproj  
├── Wavlo.Domain/           # Core entities and DTOs  
│   ├── Entities/           # Models like User, Message, ChatRoom  
│   ├── DTOs/  
│   └── Wavlo.Domain.csproj  
├── Wavlo.Infrastructure/  # Data access and external services  
│   ├── Data/               # DbContext and configuration  
│   ├── Repository/         # ChatRepository, etc.  
│   ├── CloudStorage/  
│   ├── MailService/  
│   ├── OTPValidation/  
│   └── Wavlo.Infrastructure.csproj  
├── Wavlo.Tests/            # Unit/Integration tests  
│   ├── ChatRepositoryTests.cs  
│   └── Wavlo.Tests.csproj  
└── Wavlo.sln               # Solution file  
```

---

## 📑 API Documentation  

The backend API is documented using **Scalar**.  
After running the API, visit:  

```
http://localhost:<port>/scalar/v1  
```

---

## ▶️ Getting Started  

### 🔧 Backend  

```bash
cd Wavlo_Backend
dotnet restore
dotnet ef database update
dotnet run
```

> ⚠️ Update the backend API base URL in the Flutter app if needed.

---

## 🎯 Roadmap  

- [x] Core chat (text, voice, image, video)  
- [x] Voice messages  
- [x] Real-time messaging  
- [x] Sign language video support  
- [x] Sign video ➜ text  
- [x] Sign video ➜ voice  
- [x] Cloud media storage  
- [x] Enhanced accessibility UI  
- [ ] Push notifications  
- [ ] Multilingual sign support  

---

## 🧠 Vision  

**Wavlo** is more than just a chat app — it’s a step toward **inclusive communication**.  
We believe everyone deserves to express themselves freely, and through AI and sign language recognition, we're working to make that possible.

---

## 📜 License  

This project is licensed under the **MIT License**.

---

## 🌐 Repository  

[https://github.com/shahdyassin/Wavlo_App](https://github.com/shahdyassin/Wavlo_App)

---

## 🤝 Contributors  

| Name         | GitHub                                          | LinkedIn                                                 |
|--------------|-------------------------------------------------|----------------------------------------------------------|
| Shahd Yassin | [@shahdyassin](https://github.com/shahdyassin) | [Shahd Yassin](https://www.linkedin.com/in/shahd-yassin/) |
| Ziad Yousef  | [@ziadyousef1](https://github.com/ziadyousef1) | [Ziad Yousef](https://www.linkedin.com/in/ziad-yousef-14b3a0249/) |
