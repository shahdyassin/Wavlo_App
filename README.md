# 📱 Wavlo - A Sign Language Powered Chat App

**Wavlo** is a real-time chat application that offers a full WhatsApp-like experience while breaking communication barriers for the **deaf and mute** community.

It combines **standard chat features** with **AI-based sign language video translation**, enabling inclusive communication like never before.

---

## 🚀 Features

### ✅ Core Chat Features
- 💬 Private & group messaging
- 🎙️ Send voice messages
- 📍 Share location
- 😄 Emojis and stickers
- 🎥 Send video messages
- 🔄 Edit and delete messages
- 🔔 Real-time notifications (SignalR)

### ♿ Accessibility-First Features
- 👋 **Send sign language video messages**
- ✨ **Translate sign language video into:**
  - 📄 Text (readable message)
  - 🔊 Voice message (convert for hearing users)
- 🌐 Currently supports English sign language (multi-language support in progress)

---

## 🛠️ Tech Stack

| Layer       | Tech                          |
|-------------|-------------------------------|
| Backend     | ASP.NET Core                  |
| Frontend    | Flutter                       |
| Auth        | JWT Tokens + ASP.NET Identity |
| Realtime    | SignalR                       |
| Database    | SQL Server                    |
| Docs        | Scalar                        |

---

## 📸 Screenshots

> _Coming soon: screenshots or demo videos of the app UI and the sign language translation feature._

---

## 📁 Repository Structure

Wavlo_App/
├── Wavlo_Backend/ # ASP.NET Core backend API
├── Wavlo_Frontend/ # Flutter mobile frontend


## 📑 API Documentation

The backend API is documented using **Scalar**.  
After running the API, open:

http://localhost:<port>/scalar/v1


## ▶️ How to Run

### 🔧 Backend
```bash
cd Wavlo_Backend
dotnet restore
dotnet ef database update
dotnet run


## 🎯 Roadmap

- [x] Core chat (text, voice, image, Real-Time Videos)
- [x] Voice messages
- [x] Real-time messaging
- [x] Sign language video support
- [x] Sign video ➜ text
- [x] Sign video ➜ voice
- [ ] Cloud media storage
- [ ] Enhanced accessibility UI

## 🧠 Vision

**Wavlo** isn’t just a chat app — it’s a step toward **inclusive communication**.  
We believe everyone deserves to express themselves freely, and with AI and sign language recognition, we're trying to make that happen.

## 👨‍💻 Developed By

**Shady Yassin**  
GitHub: [@shahdyassin](https://github.com/shahdyassin)  
LinkedIn: [linkedin.com/in/[your-profile](https://www.linkedin.com/in/shahd-yassin/)](https://linkedin.com/in/[your-profile](https://www.linkedin.com/in/shahd-yassin/))

## 📜 License

MIT License

## 🌐 Repository

[https://github.com/shahdyassin/Wavlo_App](https://github.com/shahdyassin/Wavlo_App)
