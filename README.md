# dotnet-template-spike

## Install Packages

From the root directory lets install the packages

`dotnet new install .\`

## Uninstall packages

From the root directory

`dotnet new uninstall .\`

## Testing

create an `output` folder in the root directory

`mkdir output`
`cd output`

### Create template using MS template

In the output directory, run the command to create a new web api project.

`dotnet new webapi`

With the web api working, we can now install our templates incrementally.

### Install Cosmos

From the output directory

`dotnet new stacks-cosmos`

### Install Mongo

From the output directory

`dotnet new stacks-mongo`

### Create project in one go

` dotnet new template-spike --database Cosmos`

Where `-database` is an optional parameter that takes the following arguments: 
- `Cosmos` 
- `Mongo`