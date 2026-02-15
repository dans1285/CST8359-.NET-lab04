# Lab 3 Workshop RSVP - Azure Deployment Guide

## Quick Deploy to Azure (Visual Studio)

### Step 1: Open Project
1. Open Visual Studio
2. File → Open → Project/Solution
3. Navigate to `C:\Users\danie\Documents\.net\LAB03\Lab3WorkshopRsvp`
4. Open `Lab3WorkshopRsvp.csproj`

### Step 2: Publish to Azure
1. Right-click the project in Solution Explorer
2. Select **Publish**
3. Choose **Azure** → Next
4. Select **Azure App Service (Windows)** → Next
5. Sign in to your Azure account
6. Click **Create New** App Service

### Step 3: Configure App Service
Fill in the following:
- **Name**: `lab3-workshop-rsvp-<yourlastname>` (must be globally unique)
- **Subscription**: Select your Azure subscription
- **Resource Group**: Create new → `Lab3ResourceGroup`
- **Hosting Plan**: Create new → Select **Free F1** tier
- Click **Create**

### Step 4: Deploy
1. Click **Finish** to create the publish profile
2. Click **Publish** button
3. Wait for deployment (2-3 minutes)
4. Browser will automatically open your Azure URL

### Step 5: Test on Azure
Your app will be at: `https://lab3-workshop-rsvp-<yourlastname>.azurewebsites.net`

Test all features:
- ✅ Navigate to Workshops
- ✅ Submit RSVP form
- ✅ Verify confirmation message
- ✅ View registrations table

### Step 6: Take Screenshot
1. Open the deployed app in your browser
2. Navigate to the Registrations page with at least 2 entries
3. Take a full-page screenshot showing:
   - The Azure URL in the address bar
   - The registrations table with data
   - The navigation menu

---

## Alternative: Deploy via Azure CLI

### Prerequisites
```powershell
# Install Azure CLI if not already installed
winget install Microsoft.AzureCLI
```

### Deployment Commands
```powershell
# 1. Login to Azure
az login

# 2. Create resource group
az group create --name Lab3ResourceGroup --location eastus

# 3. Create App Service Plan (Free tier)
az appservice plan create `
  --name Lab3Plan `
  --resource-group Lab3ResourceGroup `
  --sku FREE `
  --location eastus

# 4. Create Web App
az webapp create `
  --name lab3-workshop-rsvp-<yourlastname> `
  --resource-group Lab3ResourceGroup `
  --plan Lab3Plan `
  --runtime "DOTNET|8.0"

# 5. Build and publish
cd C:\Users\danie\Documents\.net\LAB03\Lab3WorkshopRsvp
dotnet publish -c Release -o ./publish

# 6. Create deployment package
Compress-Archive -Path ./publish/* -DestinationPath ./deploy.zip -Force

# 7. Deploy to Azure
az webapp deployment source config-zip `
  --resource-group Lab3ResourceGroup `
  --name lab3-workshop-rsvp-<yourlastname> `
  --src ./deploy.zip

# 8. Open in browser
az webapp browse `
  --name lab3-workshop-rsvp-<yourlastname> `
  --resource-group Lab3ResourceGroup
```

---

## GitHub Repository Setup

### Create Repository
```powershell
cd C:\Users\danie\Documents\.net\LAB03\Lab3WorkshopRsvp

# Initialize Git
git init
git add .
git commit -m "Lab 3: Workshop RSVP MVC Application"

# Create .gitignore for .NET
# (Add standard .NET gitignore content)

# Connect to GitHub
git remote add origin https://github.com/<yourusername>/lab3-workshop-rsvp.git
git branch -M main
git push -u origin main
```

### Create .gitignore
Create a file named `.gitignore` in the project root:
```
bin/
obj/
.vs/
*.user
*.suo
publish/
deploy.zip
```

---

## Troubleshooting

### Issue: App Name Already Taken
**Solution**: Add more unique identifier to the name:
```
lab3-workshop-rsvp-<yourlastname>-<randomnumber>
```

### Issue: Deployment Fails
**Solution**: Check the deployment logs in Azure Portal:
1. Go to Azure Portal → App Services
2. Select your app
3. Click "Deployment Center" → "Logs"

### Issue: App Shows Error Page
**Solution**: Enable detailed errors:
1. Azure Portal → App Services → Your App
2. Configuration → Application Settings
3. Add new setting:
   - Name: `ASPNETCORE_ENVIRONMENT`
   - Value: `Development`
4. Save and restart

### Issue: Static Files Not Loading
**Solution**: Verify `app.UseStaticFiles()` is in `Program.cs` (already included)

---

## Submission Checklist

For Brightspace submission, you need:

1. ✅ **Azure URL**
   - Example: `https://lab3-workshop-rsvp-smith.azurewebsites.net`

2. ✅ **Screenshot**
   - Must show Azure URL in browser
   - Must show working application
   - Recommended: Screenshot of Registrations page with data

3. ✅ **GitHub Repository Link**
   - Example: `https://github.com/yourusername/lab3-workshop-rsvp`
   - Make sure repository is public

---

## Cost Information

- **Free Tier (F1)**: $0/month
  - 60 minutes/day compute time
  - 1 GB disk space
  - Perfect for lab assignments

**Note**: Remember to delete resources after grading to avoid any charges:
```powershell
az group delete --name Lab3ResourceGroup --yes
```
