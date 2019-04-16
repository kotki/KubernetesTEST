FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["KubernetesTEST4.csproj", "."]
RUN dotnet restore "./KubernetesTEST4.csproj"
COPY . .
#WORKDIR "/src/KubernetesTEST4"
RUN dotnet build "KubernetesTEST4.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "KubernetesTEST4.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "KubernetesTEST4.dll"]