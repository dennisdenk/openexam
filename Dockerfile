FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build

ENV TZ=Europe/Berlin

WORKDIR /app

RUN apk add yarn python3 g++ make icu

COPY ./src/WebUI/WebUI.csproj ./WebUI/

RUN dotnet restore ./WebUI/

RUN apk add tzdata \
    && cp /usr/share/zoneinfo/${TZ} /etc/localtime \
    && echo "${TZ}" > /etc/timezone

COPY ./src ./

WORKDIR /app/WebUI

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

WORKDIR /app

# RUN dotnet --info
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
# RUN apk add icu

COPY --from=build /app/WebUI/out ./
# COPY --from=build /app/WebUI/ecdsaCert.pfx ./
#COPY --from=build /app/WebApi/MappeNew.csv .

# RUN apk add texlive \
#        texlive-xetex \
#        texmf-dist \
#        texmf-dist-formatsextra \
#        texmf-dist-latexextra \
#        texmf-dist-pictures \
#        texmf-dist-science

ENV ASPNETCORE_URLS=http://0.0.0.0:5000

EXPOSE 5000

ENTRYPOINT ["dotnet", "OpenExam.WebUI.dll"]
# ENTRYPOINT ["ls", "."]