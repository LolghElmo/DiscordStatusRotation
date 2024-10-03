# Discord Status Rotator
---
This project is a Discord Status Rotator built with **.NET 8.0**. It allows you to automatically rotate between different statuses on Discord at set intervals. Please note that this project requires you to input your Discord token, and this could potentially lead to a ban from Discord if misused. Use at your own risk.

## Requirements
- **.NET 8.0** is required to run this project.
- You will need your **Discord Token** to use the status rotator.

## Features
- **Save your Discord token** in a `.json` file for reuse.
- **Add or delete custom statuses** that will rotate on your Discord account.
- You can specify the time interval for status changes (recommended to set it for more than 5 minutes).
- All your statuses and token are saved locally in a JSON file.

## Setup Instructions
1. **Download and install .NET 8.0** if you haven't already. You can get it from [here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).
2. **Get your Discord token** (this will need to be manually retrieved).
3. **Run the application** and enter your Discord token in the provided textbox.
4. Your token will be saved in a JSON file locally.

## JSON File Structure
Once your token and statuses are saved, the project stores them in a `.json` file. The structure of the file looks like this:

```json
{
  "discord_token": "",
  "quotes": [],
  "current_index": 0
}
```

- **discord_token**: Your Discord token is saved here.
- **quotes**: Each status you add will be saved in this array.
- **current_index**: This is used to track which status is currently active.

### Example:
After adding some statuses, the file might look like this:

```json
{
  "discord_token": "your-discord-token-here",
  "quotes": [
    "Status 1",
    "Status 2",
    "Status 3"
  ],
  "current_index": 0
}
```

### Important Note:
Using this application **may lead to your Discord account being banned**. We recommend using intervals of 5 minutes or more to minimize the risk. Please use this tool responsibly.

## Disclaimer
This project is for educational purposes only. Use it at your own risk. We are not responsible for any actions taken by Discord against your account.

---
