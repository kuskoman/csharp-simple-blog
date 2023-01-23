.DEFAULT_GOAL := all

docker:
	docker-compose up -d

api:
	cd SimpleBlog && dotnet run

web:
	cd SimpleBlog.Web/ClientApp && yarn serve

all:
	make -j 3 api web docker
