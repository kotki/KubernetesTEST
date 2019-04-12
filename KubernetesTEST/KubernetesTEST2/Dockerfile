FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["KubernetesTEST2.csproj", "."]
RUN dotnet restore "./KubernetesTEST2.csproj"
COPY . .
#WORKDIR "/src/KubernetesTEST2"
RUN dotnet build "KubernetesTEST2.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "KubernetesTEST2.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_URLS http://*:5123
ENTRYPOINT ["dotnet", "KubernetesTEST2.dll"]