# Build stage
FROM microsoft/dotnet:2.2-sdk AS build

WORKDIR /app

COPY WebReactApp.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release --output /publish

# Build Client stage
FROM node:12.2.0-alpine as clientBuild

WORKDIR /app
ENV PATH /app/node_modules/.bin:$PATH

COPY ./ClientApp/package.json /app/package.json
RUN npm install --silent

COPY ./ClientApp /app
RUN npm run build

# Runtime Image stage
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /publish

COPY --from=build /publish .
COPY --from=clientBuild /app/build /publish/wwwroot

ENTRYPOINT ["dotnet", "WebReactApp.dll"]