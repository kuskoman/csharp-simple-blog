FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

ARG NVM_VERSION=0.39.3 \
    NODE_VERSION=18.13.0

WORKDIR /App

SHELL ["/bin/bash", "-c"]

RUN curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v${NVM_VERSION}/install.sh | bash && \
    source $HOME/.nvm/nvm.sh && \
    nvm install "${NODE_VERSION}" && \
    npm i -g yarn

COPY . .
RUN source $HOME/.nvm/nvm.sh && \
    dotnet restore && \
    dotnet publish -o out


FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "SimpleBlog.Web.dll"]
