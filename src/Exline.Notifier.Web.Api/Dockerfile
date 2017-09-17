FROM microsoft/aspnetcore:1.1
ARG source
COPY ${source:-./bin/Debug/netcoreapp1.1/} .
EXPOSE 80
ENTRYPOINT ["dotnet","Exline.Notifier.Web.Api.dll"]






