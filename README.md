# Read Gas Price Index from PEGAS Website

## Description

Read, store and display gas hub index prices from [PowerNext PEGAS Gas Index website](https://www.powernext.com/spot-market-data) using C# and SQLite.

![PEGASGasIndexWebScraping](https://user-images.githubusercontent.com/42610159/194009259-736f4d0e-6ea9-4786-b171-e77f3794a209.jpg)

## Requirements
- .NET 4.6
- System.Data.SQLite.Core
- SQLite database (included in the repository)

## How do I use it?

1. Include the project in your Visual Studio C# project and download dependencies as described in packages.config file
2. Compile and run the application and click "Download PEGAS index". This will download gas hub indexes from PEGAS website.

## Features

1. Downloading one month of gas hub index prices from PEGAS website
2. Storing gas hub index prices in SQLite database, inserting new values or updating old ones if entry for the specific day and gas hub already exists.
3. Displaying the data in C# application.
4. Possibility to export data into CSV format for further analysis.
5. Since the program downloads one month of data for complete history one download per month would be required.
