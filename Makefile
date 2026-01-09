INFRA_PROJECT=Infrastructure
STARTUP_PROJECT=Presentation

# Default environment (can be overridden)
ENV ?= Development

.PHONY: migration update-db remove-migration

migration:
	@if [ -z "$(name)" ]; then \
		echo "❌ Missing migration name. Usage: make migration name=MigrationName"; \
		exit 1; \
	fi
	ASPNETCORE_ENVIRONMENT=$(ENV) \
	dotnet ef migrations add $(name) \
		--project $(INFRA_PROJECT) \
		--startup-project $(STARTUP_PROJECT)

update-db:
	ASPNETCORE_ENVIRONMENT=$(ENV) \
	dotnet ef database update \
		--project $(INFRA_PROJECT) \
		--startup-project $(STARTUP_PROJECT)

remove-migration:
	ASPNETCORE_ENVIRONMENT=$(ENV) \
	dotnet ef migrations remove \
		--project $(INFRA_PROJECT) \
		--startup-project $(STARTUP_PROJECT)

