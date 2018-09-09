FROM microsoft/dotnet:2.1-sdk as build

COPY . ./

WORKDIR /lanches.api

RUN dotnet restore &&  dotnet publish -c Release -o Project

FROM microsoft/dotnet:2.1-aspnetcore-runtime

COPY --from=build /lanches.api/Project ./app

WORKDIR /app

ENV TZ=America/Sao_Paulo

RUN echo 'America/Sao_Paulo' > /etc/timezone

ENTRYPOINT ["dotnet", "lanches.api.dll"]