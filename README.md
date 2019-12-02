![Mjolnir](https://gitlab.com/tobiaskoch/Mjolnir/raw/master/img/Mjolnir.png)

# ᛗᛁᚮᛚᚾᛁᚱ

*One of the most fearsome and powerful tools in existence, capable of leveling mountains*

---
This is the framework library I use in (most of) my projects.

## Installation

### Option 0: NuGet
NuGet packages are available [here](https://www.nuget.org/packages/Mjolnir/).

### Option 1: Source
#### Requirements
The following tools must be available:

* [.NET Core SDK 3.0](https://dotnet.microsoft.com/download)
* [.NET 4.7.2 Dev Pack](https://dotnet.microsoft.com/download)
* [.NET 4.7.1 Dev Pack](https://dotnet.microsoft.com/download)
* [.NET 4.7 Dev Pack](https://dotnet.microsoft.com/download)

#### Source code
Get the source code using the following command:

    > git clone https://gitlab.com/tobiaskoch/Mjolnir.git

#### Test
    > ./build.ps1

The script will report if the tests succeeded; the coverage report will be located in the directory *./src/Mjolnir.Tests/bin/Debug/Coverage/*.

#### Build
    > ./build.ps1 --configuration=Release

The libraries will be located in the directory *./src/Mjolnir/bin/Release* if the build succeeds.

## Usage
The documentation of this library can be found here: [https://tobiaskoch.gitlab.io/Mjolnir/](https://tobiaskoch.gitlab.io/Mjolnir/)

## Contributing
see [CONTRIBUTING.md](https://gitlab.com/tobiaskoch/Mjolnir/blob/master/CONTRIBUTING.md)

## Contributors
see [AUTHORS.txt](https://gitlab.com/tobiaskoch/Mjolnir/blob/master/AUTHORS.txt)

## Donating
Thanks for your interest in this project. You can show your appreciation and support further development by [donating](https://www.tk-software.de/donate).

## License
**Mjolnir** © 2017-2019  [Tobias Koch](https://www.tk-software.de). Released under the [MIT License](https://gitlab.com/tobiaskoch/Mjolnir/blob/master/LICENSE.md).
