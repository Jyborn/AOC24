FROM mcr.microsoft.com/dotnet/runtime:8.0 AS build

# Install NativeAOT build prerequisites
RUN apt-get update && apt-get install -y --no-install-recommends \
       clang \
       zlib1g-dev

WORKDIR /source
COPY day02.csproj .
COPY Program.cs .
COPY Puzzle.cs .
COPY input.txt .
RUN dotnet publish -c Release -o publish --use-current-runtime -p:"PublishAot=true;StripSymbols=true;IlcOptimizationPreference=Speed"

FROM mcr.microsoft.com/dotnet/runtime-deps:8.0
WORKDIR /app
COPY --from=build /source/publish .
ENTRYPOINT [ "./day02" ]