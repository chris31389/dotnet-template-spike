# dotnet-template-spike

## Install Packages

From the route directory lets install the packages

`dotnet new install .\`

## Uninstall packages

From the root directory

`dotnet new uninstall .\templates`

## Testing

create an `output` folder in the root directory

`mkdir output`
`cd output`

In the output directory, run the command to create a new web api project.

`dotnet new webapi`

With the web api working, we can now install our templates incrementally.

### Install Cosmos

`dotnet new stacks-cosmos`

### Install Mongo

`dotnet new stacks-mongo`

