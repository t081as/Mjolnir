![Mjolnir](https://gitlab.com/tobiaskoch/Mjolnir/raw/master/img/Mjolnir.png)

# ᛗᛁᚮᛚᚾᛁᚱ

*One of the most fearsome and powerful tools in existence, capable of leveling mountains*

---
This is a common library for .NET applications.

## Installation

### Option 0: NuGet
NuGet packages are available [here](https://www.nuget.org/packages/Mjolnir/).

### Option 1: Source
#### Requirements
The following tools must be available:

* [.NET Core SDK 3.1 (Windows)](https://dotnet.microsoft.com/download)

#### Source code
Get the source code using the following command:

    > git clone https://gitlab.com/tobiaskoch/Mjolnir.git

#### Test
    > ./build.ps1

The script will report if the tests succeeded; the coverage report will be located in the directory *./output/coverage/*.

#### Build
    > ./build.ps1 --configuration Release

The script will report if the build succeeded; the libraries will be located in the directories *./src/../bin/Release*.

#### Generate packages
    > ./build.ps1 --configuration Release --target Pack

The nuget packages will be located in the directory *./output* if the build succeeds.

## Contributing
see [CONTRIBUTING.md](https://gitlab.com/tobiaskoch/Mjolnir/blob/master/CONTRIBUTING.md)

## Contributors
see [AUTHORS.txt](https://gitlab.com/tobiaskoch/Mjolnir/blob/master/AUTHORS.txt)

## Donating
Thanks for your interest in this project. You can show your appreciation and support further development by [donating](https://www.tk-software.de/donate).

## License
**Mjolnir** © 2017-2020  [Tobias Koch](https://www.tk-software.de). Released under the [MIT License](https://gitlab.com/tobiaskoch/Mjolnir/blob/master/LICENSE.md).
