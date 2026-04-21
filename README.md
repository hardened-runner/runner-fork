# Runner-Fork

## Development

### Building
To build and initally download all externals run ```./dev.sh layout```. After that run ```./dev.sh build```to rebuild. This avoid re-downloading all externals on every build. Not running the inital ./dev.sh layout - command will cause some tests to fail. Alternatively you can run ```dotnet build ActionsRunner.sln```, but the ./dev.sh script allows to build OS - independently.

### Testing
 The ./dev.sh script does not currently allow to filter tests. So the approach is to build the project using ./dev script and run tests using dotnet with the ```--no-build```flag.

 1. ```./dev.sh build && dotnet test --no-build --filter "Feature!=SelfUpdate" ActionsRunner.sln ```
 Command for running all tests of the original github action/runner repository as well as the tests specific to this fork.
 2. ```./dev.sh build && dotnet test --no-build --filter "Category=HardenedRunner" ActionsRunner.sln ```
 Command for running only tests specific to this fork, ignoring the usuall tests of the upstream github action/runner repository.