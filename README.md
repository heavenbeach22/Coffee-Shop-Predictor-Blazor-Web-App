# Coffee Predictor App

A Blazor Web Application that recommends nearby coffee shops based on user location, visit history, and preferences.  
Developed as part of my Object-Oriented Programming coursework at Swinburne University Vietnam.

---

## Overview
**Coffee Predictor** helps users discover and predict their next favorite coffee spot using local JSON data and custom distance calculations.  
It’s fully self-contained — no external APIs required — making it lightweight and easy to run.

---

## Features
- **Manual Location Input:** Uses manually entered longitude and latitude for distance-based filtering  
- **Smart Filtering:** “For You”, “Nearest”, and “Rating” modes  
- **User System:** Supports both `BaseUser` and `PremiumUser` classes  
- **Prediction Logic:** Suggests the next shop based on user visit history stored in JSON  
- **OOP Architecture:** Encapsulation, inheritance, and polymorphism across models and services  
- **Simple UI:** Built with Blazor components and Bootstrap styling  

---

## Project Structure
CoffeePredictor/
├── wwwroot/
│ ├── data/
│ │ ├── coffeeshop.json
│ │ ├── history.json
│ │ └── fullhistory.json
│ ├── bootstrap/
│ └── app.css
├── Components/
│ └── Layout/
│ ├── MainLayout.razor
│ └── MainLayout.razor.css
├── Pages/
│ ├── Find.razor
│ ├── History.razor
│ ├── Login.razor
│ ├── Predictor.razor
│ └── Error.razor
├── Models/
│ ├── BaseUser.cs
│ ├── CoffeeShop.cs
│ ├── PremiumUser.cs
│ └── UserVisitRecord.cs
├── Services/
│ ├── DataManager.cs
│ ├── FindNearByCafe.cs
│ ├── GeoJsonConverter.cs
│ └── GeoJsonFeature.cs
├── App.razor
├── Routes.razor
└── Program.cs

---

## Tech Stack
- **Language:** C# (.NET 8)
- **Framework:** Blazor WebAssembly  
- **Data Storage:** Local JSON files  
- **UI:** Bootstrap + CSS  
- **Map Handling:** Manual longitude/latitude distance calculations (no Google Maps API)

---

## Screenshots of UI
*(Add your screenshots later if you want to show UI)*

---

## Future Improvements
- Add map visualization feature  
- Enable database or API integration for real-time updates  
- Improve prediction accuracy with data-driven analysis  

---

## Author
**Zoe**  
2nd Year Computer Science Student — Swinburne University Vietnam  
Passionate about Cloud Computing, Data Science, and building creative, data-driven solutions.  

---


