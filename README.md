
A Blazor Web Application that recommends nearby coffee shops based on user location, visit history, and preferences.  
Developed as part of my Object-Oriented Programming coursework at Swinburne University Vietnam.

---

## Overview
**Coffee Predictor** helps users discover and predict their next favorite coffee spot using local JSON data and custom distance calculations.  
It’s fully self-contained, no external APIs required, making it lightweight and easy to run.
*Note*: The coffee shop dataset currently covers only Tân Bình district, HCMC. Locations outside this area may not return results.

---

## Features
- **Manual Location Input:** Uses manually entered longitude and latitude for distance-based filtering
- **Login/Logout functionality**: Uses simple login/logout flow  
- **Smart Filtering:** “For You”, “Nearest”, and “Rating” modes  
- **User System:** Supports both `BaseUser` and `PremiumUser` classes. The `BaseUser` could not allow to access to view the history page.
- **Prediction Logic:** Suggests the next shop based on user visit history stored in JSON  
- **OOP Architecture:** Encapsulation, inheritance, and polymorphism across models and services  
- **Simple UI:** Built with Blazor components and Bootstrap styling

---
## Login Info
- **Premium user:** `zoe` / `123`
- **Normal user:** `guest` / `123`
  
---
## How to Run
1. Clone the repo:
   ```bash
   git clone https://github.com/yourusername/coffee-predictor.git
2. Open Microsoft Visual Studio to run project
3. Login using the credentials given above
4. For the location information, it is recommended to get both the longitude and latitude of locations around Tân Bình district, Ho Chí Minh city.

---
## Project Structure
```
CoffeePredictor/
├── wwwroot/
│   ├── data/
│   │   ├── coffeeshop.json
│   │   ├── history.json
│   │   └── fullhistory.json
│   ├── bootstrap/
│   └── app.css
├── Components/
│   └── Layout/
│       ├── MainLayout.razor
│       └── MainLayout.razor.css
├── Pages/
│   ├── Find.razor
│   ├── History.razor
│   ├── Login.razor
│   ├── Predictor.razor
│   └── Error.razor
├── Models/
│   ├── BaseUser.cs
│   ├── CoffeeShop.cs
│   ├── PremiumUser.cs
│   └── UserVisitRecord.cs
├── Services/
│   ├── DataManager.cs
│   ├── FindNearByCafe.cs
│   ├── GeoJsonFeature.cs
│   ├── GeoJsonGeometry.cs
│   ├── GeoJsonParser.cs
│   ├── GeoJsonProperties.cs
│   ├── GeoJsonRoot.cs
│   ├── ICoffeePredictor.cs
│   ├── SmartCount.cs
│   ├── UserState.cs
│   ├── VisitCountPredictor.cs
│   └── VisitRecordExtensions.cs
├── App.razor
├── Routes.razor
└── Program.cs
```
---

## Tech Stack
- **Language:** C# (.NET 8)
- **Framework:** Blazor WebAssembly  
- **Data Storage:** Local JSON files  
- **UI:** Bootstrap + CSS  
- **Map Handling:** Manual longitude/latitude distance calculations (no Google Maps API)

---
## Prediction Logic / Math Analysis

The Coffee Predictor uses different strategies based on user type:

### Premium User (`SmartCount`)
- Predicts the next coffee shop using **both visit frequency and recency**.
- Each shop in the user’s history is scored as:
Score = (VisitCount × 1.5) + RecencyScore
RecencyScore = 1 / (DaysSinceLastVisit + 1)

- The shop with the highest score is recommended.
- This ensures frequently visited and recently visited shops are prioritized.

### Normal User (`VisitCountPredictor`)
- Predicts the next coffee shop based **solely on the most visited shop**.
- Ignores recency; only counts total visits.

> *Premium users get smarter recommendations by combining frequency and recency, while normal users see a simpler “most visited” prediction.*

---
## Screenshots of UI

The Login page:
<img width="2822" height="1547" alt="image" src="https://github.com/user-attachments/assets/3dd9040c-c2eb-4e4f-84b4-5ae634af6939" />

The premium landing page:
<img width="2817" height="1547" alt="image" src="https://github.com/user-attachments/assets/152d17a4-0dca-40d3-aa94-2446d9f80783" />

The guest landing page:
<img width="2819" height="1540" alt="image" src="https://github.com/user-attachments/assets/247f6dc2-cff4-4e6e-bf6c-dfca1da041ba" />

The find page:
<img width="2830" height="1547" alt="image" src="https://github.com/user-attachments/assets/6dfa1f35-aa5a-4be3-8fc7-5df061626e32" />

The predict page:
<img width="2824" height="1544" alt="image" src="https://github.com/user-attachments/assets/4bbb43f2-6cf9-4d6a-bcc9-bbf928bd6c5b" />

The history page for PremiumUser:
<img width="2820" height="1551" alt="image" src="https://github.com/user-attachments/assets/29939b4b-cd67-454e-b103-57e25eba45c5" />

---

## Future Improvements
- Add map visualization feature  
- Enable database or API integration for real-time updates  
- Improve prediction accuracy with data-driven analysis  

---

## Author
**Nguyễn Lê Thùy Dương (Zoe)**  
2nd Year Computer Science Student — Swinburne University Vietnam  
Passionate about Cloud Computing, Data Science, and building creative, data-driven solutions.  

---


