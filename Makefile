# # Rest client Makefile

ifeq ($(OS), Windows_NT)
	Client := no-client
else
	Client := ./src/GtkClient/GtkClient.csproj
endif

.PHONY: run test

# Commands _(make targets)_:

# - `help` - Prints help message
default help: 
	@cat $(shell pwd)/Makefile | grep -E "^#" | sed "s/^[#]/ /g" | gum format

# - `run` - Runs client project
run:
	dotnet run --project $(Client)

# - `test` - Runs all tests
test: 
	dotnet test
#
# For more info about building visit [project repo](https://github.com/IS2-19/RESTClient)
