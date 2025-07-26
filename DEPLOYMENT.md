# GitHub Pages Deployment Guide

This document explains how to deploy the Gantt Chart application to GitHub Pages using GitHub Actions.

## Prerequisites

1. **GitHub Repository**: Your code must be in a GitHub repository
2. **Syncfusion License Key**: You need a valid Syncfusion license key for the components to work properly

## Setup Instructions

### 1. Configure GitHub Repository Settings

1. Go to your GitHub repository
2. Navigate to **Settings** → **Pages**
3. Under **Source**, select **GitHub Actions**
4. This enables GitHub Pages deployment via Actions

### 2. Configure Syncfusion License Key Secret

1. In your GitHub repository, go to **Settings** → **Secrets and variables** → **Actions**
2. Click **New repository secret**
3. Set the following:
   - **Name**: `SYNCFUSION_LICENSE_KEY`
   - **Value**: Your actual Syncfusion license key
4. Click **Add secret**

### 3. Enable GitHub Actions

The workflow file `.github/workflows/deploy-to-pages.yml` is already configured and will:

- **Trigger on**: Push to main branch, pull requests, or manual dispatch
- **Build**: Compile the .NET Blazor application
- **Configure**: Set up proper base href for GitHub Pages subdirectory
- **Deploy**: Publish to GitHub Pages automatically

### 4. Deployment Process

Once configured, the deployment happens automatically:

1. **Push changes** to the `main` branch
2. **GitHub Actions** will trigger the workflow
3. **Build process** will use your Syncfusion license key from secrets
4. **Application** will be deployed to `https://yourusername.github.io/repositoryname/`

## How It Works

### License Key Configuration

The application checks for the Syncfusion license key in this order:

1. **Environment Variable**: `SYNCFUSION_LICENSE_KEY` (used by GitHub Actions)
2. **User Secrets**: `Syncfusion:LicenseKey` (used for local development)

### GitHub Actions Workflow

The workflow performs these steps:

1. **Checkout**: Gets the latest code
2. **Setup .NET**: Installs .NET 9.0
3. **Restore**: Downloads NuGet packages
4. **Build**: Compiles the application with license key
5. **Publish**: Creates deployment-ready files
6. **Configure**: Sets up GitHub Pages routing and base href
7. **Deploy**: Publishes to GitHub Pages

### File Structure

```
.github/
  workflows/
    deploy-to-pages.yml     # GitHub Actions workflow
GanttChartApp/
  wwwroot/
    .nojekyll              # Prevents Jekyll processing
  Program.cs               # License key configuration
```

## Local Development

For local development, configure your Syncfusion license key using .NET user secrets:

```bash
cd GanttChartApp
dotnet user-secrets set "Syncfusion:LicenseKey" "your-license-key-here"
```

## Troubleshooting

### Common Issues

1. **License Key Not Working**
   - Verify the secret name is exactly `SYNCFUSION_LICENSE_KEY`
   - Check that your license key is valid and not expired

2. **Deployment Fails**
   - Check the Actions tab for detailed error logs
   - Ensure GitHub Pages is enabled in repository settings

3. **App Not Loading**
   - Verify the base href is correctly set for your repository name
   - Check browser console for any JavaScript errors

### Monitoring Deployments

1. Go to **Actions** tab in your GitHub repository
2. Click on the latest workflow run
3. Review logs for any errors or warnings
4. Check the deployment URL once completed

## Security Notes

- The Syncfusion license key is stored securely as a GitHub secret
- It's only accessible during the build process
- Never commit license keys directly to your repository
- The key is not exposed in the deployed application

## Support

If you encounter issues:

1. Check the GitHub Actions logs for detailed error messages
2. Verify your Syncfusion license key is valid
3. Ensure all repository settings are configured correctly
4. Review the deployment URL format matches your repository structure
