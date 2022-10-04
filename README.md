# Read Gas Price Index from PEGAS Website

## Description

Read gas hub index prices from [PowerNext PEGAS Gas Index website](https://www.powernext.com/spot-market-data)
 ![PEGASGasIndexWebScraping](https://user-images.githubusercontent.com/42610159/193825453-255ce97a-80fe-492e-9251-0607174b71ad.jpg)

## Requirements
- .NET 4.6
- System.Data.SQLite.Core
- SQLite database (included in repository)

## How do I use it?

1. Include the project in your Visual Studio C# project, download dependencies as described in packages.config file
2. Compile and run the application and click "Download PEGAS index". This will 

## Features

1. Downloading one month of gas hub index prices from PEGAS API
2. Storing gas hub index prices in SQLite database, inserting new values or updating old ones if entry for the specific day and gashub doesn't exist.
3. Allows export into CSV format for further analysis.
4. Since it downloads one month of data it is required to run the program once per month to create history of prices
