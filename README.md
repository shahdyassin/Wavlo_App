# 📱 Wavlo - A Sign Language Powered Chat App  
**Wavlo** is a real-time chat application that offers a full WhatsApp-like experience while breaking communication barriers for the **deaf and mute** community.  
It combines **standard chat features** with **AI-based sign language video translation**, enabling inclusive communication like never before.  

## 🚀 Features  
### ✅ Core Chat Features  
- 💬 Private & group messaging  
- 🎙️ Voice messaging  
- 🎥 Send video messages  
- 🔄 Edit and delete messages  
- 🔔 Real-time messaging via SignalR  
- 📍 Share location _(coming soon)_  
- 😄 Emojis and stickers _(coming soon)_  

### ♿ Accessibility-First Features  
- 👋 **Send sign language video messages**  
- ✨ **Translate sign language video into:**  
  - 📄 Readable **text**  
  - 🔊 **Voice** message for hearing users  
- 🌐 Currently supports **English Sign Language** _(multi-language support in progress)_  

## 🛠️ Tech Stack  
| Layer     | Technology                      |  
|-----------|----------------------------------|  
| Backend   | ASP.NET Core                     |  
| Frontend  | Flutter                          |  
| Auth      | JWT Tokens + ASP.NET Identity    |  
| Realtime  | SignalR                          |  
| Database  | SQL Server                       |  
| Docs      | Scalar                           |  

## 📁 Project Structure  
```
Wavlo_App/  
├── Wavlo_Backend/   # ASP.NET Core backend API  
└── Wavlo_Frontend/  # Flutter mobile app  
```  

## 📑 API Documentation  
The backend API is documented using **Scalar**.  
After running the API, open your browser at:  
```
http://localhost:<port>/scalar/v1  
```  

## ▶️ How to Run  
### 🔧 Backend  
```bash  
cd Wavlo_Backend  
dotnet restore  
dotnet ef database update  
dotnet run  
```  

### 📱 Frontend  
```bash  
cd Wavlo_Frontend  
flutter pub get  
flutter run  
```  

> ⚠️ Make sure to update the backend API URL in the Flutter app if needed.  

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

## 🧠 Vision  
**Wavlo** isn’t just a chat app — it’s a step toward **inclusive communication**.  
We believe everyone deserves to express themselves freely, and with AI and sign language recognition, we're trying to make that happen.  

## 👨‍💻 Developed By  
**Shady Yassin**  
GitHub: [@shahdyassin](https://github.com/shahdyassin)  
LinkedIn: [Shahdy Yassin](https://www.linkedin.com/in/shahd-yassin/)  

## 📜 License  
**MIT License**  

## 🌐 Repository  
[https://github.com/shahdyassin/Wavlo_App](https://github.com/shahdyassin/Wavlo_App)
