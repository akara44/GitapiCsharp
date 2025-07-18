

# 🚀 Gitapi – Simple and Powerful GitHub Info API

This project is a **.NET Core Web API** application. It allows users to input a GitHub username and receive detailed user information as a JSON response.

> 💡 Ideal for developers who are learning API integration or need a lightweight GitHub info service.

![Project Screenshot](https://placehold.co/800x400?text=Project+Screenshot+Here)

---

## 📁 Project Structure


---

## ⚙️ Setup & Run

Follow these steps to get the project running:

### 1. Clone the Repository

```bash

git clone https://github.com/yourusername/gitapi.git
cd gitapi
```
### 2. ⚙️ Restore Dependencies
```bash

dotnet restore
```
### 3. Run the Application
```bash
dotnet run
```

After starting, you can access the API at:
https://localhost:5001

### 🔌 Usage 
data preparation in the backend
```bash
 public GitHubUser? GitUser { get; set; }
```
pulling data in the frontend section

``` bash
 <img src="@Model.GitUser.avatar_url" alt="Avatar" class="user-image" />
 
        @if (!string.IsNullOrWhiteSpace(Model.GitUser.bio))
        {
            <p class="user-bio">@Model.GitUser.bio</p>
        }

        @if (!string.IsNullOrWhiteSpace(Model.GitUser.location))
        {
            <p class="user-details">📍 @Model.GitUser.location</p>
        }
        <div class="stats">
            <div class="stat-item">
                <span>Takipçiler</span>
                <div>@Model.GitUser.followers</div>
            </div>
            <div class="stat-item">
                <span>Takip</span>
                <div>@Model.GitUser.following</div>
            </div>
            <div class="stat-item">
                <span>Repolar</span>
                <div>@Model.GitUser.public_repos</div>
            </div>
        </div>
    </div>
```


### 🧑‍💻 Developer
Ahmet Kara
GitHub: akara44

### 🪪 License
Distributed under the MIT License.

