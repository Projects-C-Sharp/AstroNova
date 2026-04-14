Migrations (EF Core)

### Environment Variables (Way 1)
Edit Your bash File (Linux)
```bash
nano ~/.bashrc
```
Add at the end of the file
```bash
export DB_HOST=localhost
export DB_NAME=dinosaurs_db
export DB_USER=root
export DB_PASSWORD=tu_password
```
Save and close AND save changes in the evironment
```
source ~/.bashrc
```
---

### Environment Variables (Way 2)
Quickly option on terminal
```bash
export DB_HOST=localhost
export DB_NAME=dinosaurs_db
export DB_USER=root
export DB_PASSWORD=tu_password
```
**This is lost when you close the terminal**

---

Afther all this commands
Add-Migration InitialCreate
```bash
dotnet ef migrations add InitialCreate
```
Update-Database
```bash
dotnet ef database update
```
---

