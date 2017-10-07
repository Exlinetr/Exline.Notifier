full-initialize:
	sudo make mkdir
	sudo make permission
	sudo make nginx-install
	sudo make nginx-config
	sudo make docker-install
	sudo make docker-compose-install
	sudo make up
semi-initialize:
	sudo make mkdir
	sudo make permission
	sudo make nginx-config
	sudo make up
mkdir:
	sudo mkdir -p /apps/notifier/data/mongo/
nginx-config:
	./scripts/nginx-config.sh
nginx-install:
	./scripts/nginx-install.sh
docker-install:
	./scripts/docker-install.sh	
docker-compose-install:
	./scripts/docker-compose-install.sh
permission:
	sudo chmod a+x ./scripts/nginx-config.sh
	sudo chmod a+x ./scripts/nginx-install.sh
	sudo chmod a+x ./scripts/docker-install.sh
	sudo chmod a+x ./scripts/docker-compose-install.sh
up:
	docker-compose up -d
down:
	docker-compose down
