# # Rest client Makefile

AppId := ru.is2-19.rest-client

ifeq ($(OS), Windows_NT)
	Client := no-client
else
	ClientDir := ./src/GtkClient
	Client := $(ClientDir)/GtkClient.csproj
endif

.PHONY: run test

# Commands _(make targets)_:

# - `help` - Prints help message
default help: 
	@cat $(shell pwd)/Makefile | grep -E "^# " | sed "s/^[#]/ /g" | gum format

# - `run` - Runs client project
run:
ifneq ($(OS), Windows_NT)
	#glib-compile-resources $(ClientDir)/Resources/$(AppId).gresource.xml
endif
	dotnet run --project $(Client)

# - `test` - Runs all tests
test: 
	dotnet test

# - `install-blueprints` - installs `blueprint-compiler` to `/usr/bin`
# **_WARN!_ This target will use sudo**
install-blueprints: 

BlueprintsSourceDir := /tmp/blueprints
install-blueprints:$(BlueprintsSourceDir)
	cd $(BlueprintsSourceDir) && \
	meson _build && \
	pkexec ninja -C $(BlueprintsSourceDir)/_build install

$(BlueprintsSourceDir): 
	git clone https://gitlab.gnome.org/jwestman/blueprint-compiler.git $@

# - `install-sourceview` - installs Gtk.SouirceView component
install-sourceview:

SourceviewSourceDir := /tmp/sourceview
install-sourceview: $(SourceviewSourceDir)
	cd $(SourceviewSourceDir) && \
	mkdir -p build && \
  meson build && \
  cd build && \
  pkexec ninja -C $(SourceviewSourceDir)/build install

$(SourceviewSourceDir):
	git clone https://gitlab.gnome.org/GNOME/gtksourceview $@

# ---
# For more info about building visit [project repo](https://github.com/IS2-19/RESTClient)
