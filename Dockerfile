FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

COPY ./SampleWebApi/out/ app/

ENTRYPOINT ["dotnet", "app/SampleWebApi.dll"]