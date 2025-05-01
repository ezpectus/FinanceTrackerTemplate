

## ⚙️ Extension Guide

Want to build your own **Finance App** on top of this template?  
You're in luck — the architecture is modular, flexible, and made to **scale** fast.



### ➕ Add a New Feature (e.g., Goal Tracking)

1. **Create a model**  
   `Models/Goal.cs`

2. **Add interface**  
   `Interfaces/IGoalService.cs`

3. **Implement business logic**  
   `Services/GoalService.cs`

4. **Create a repository (if needed)**  
   `Repositories/GoalRepository.cs`

5. **Register in DI**  
   Add bindings in `DependencyInjection/DependencyInjection.cs`

6. **Update UI**  
   - Add console commands (if CLI)
   - Add page/component (if Blazor or Web)



### 🔌 Add External APIs

You can easily integrate APIs like:

- 📈 **Currency Exchange Rates** (e.g. [exchangeratesapi.io](https://exchangeratesapi.io))
- 🏦 **Banking APIs** (like Plaid, Tink, etc.)
- 💵 **Crypto Price APIs** (CoinGecko, Binance)

Just follow the structure:
- Create API Client in `Services/`
- Abstract via `Interfaces/`
- Inject via DI for full control + testability



### 🗄️ Plug Different Databases

This template supports **dependency injection**, so you can easily swap or combine:

- **In-Memory DB** for testing/dev
- **SQLite / Local File DB** for small apps
- **PostgreSQL / MSSQL / MySQL** for production
- **MongoDB / NoSQL** via custom repositories

Use repository pattern:
```csharp
// Interface
public interface ITransactionRepository { ... }

// SQL Implementation
public class SqlTransactionRepository : ITransactionRepository { ... }

// Mongo Implementation
public class MongoTransactionRepository : ITransactionRepository { ... }
```
Then register the needed one in DI based on environment config.


### 🧪 Testing Everything

You can easily test your logic:

- ✅ Unit tests (xUnit recommended)
- 🧪 Integration tests using mock services
- 🖥️ CLI Testing: Just build a console UI that simulates input/output
- 🧑‍💻 UI Testing via Blazor test tools or Playwright


### 💻 Interface Flexibility

Same backend can support:

- 🖥️ **Console UI** — for quick CLI use (great for MVP)
- 🌐 **Blazor WebAssembly / Server** — for full-featured UI
- 📱 **MAUI / Xamarin** — for cross-platform apps

You only need to change the UI layer (`UI/`) — all business logic remains untouched.



### 🚀 Why It Works

- Built on **SOLID principles**
- Clean **Separation of Concerns**
- Full **testability** and **extensibility**
- Can be used as:
  - Startup MVP base
  - Educational project
  - Personal finance assistant



## ✅ Next Steps

- Fork it and start building your dream finance app.
- Add tests from day one.
- Build CLI first, Blazor later — or do both.
- Keep logic in Services/ — and UI super thin.
- Let others contribute with clear module structure.



