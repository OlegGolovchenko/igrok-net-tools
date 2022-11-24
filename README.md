# igrok-net-tools
igrok-tools

Visit our web site https://igrok-net.org for more information

dev branch
[![Build Status](https://igrokzp.visualstudio.com/igrok-tools/_apis/build/status/DevBuild?branchName=dev)](https://igrokzp.visualstudio.com/igrok-tools/_build/latest?definitionId=25&branchName=dev)
|
master branch
[![Build Status](https://igrokzp.visualstudio.com/igrok-tools/_apis/build/status/ReleaseBuild?branchName=master)](https://igrokzp.visualstudio.com/igrok-tools/_build/latest?definitionId=24&branchName=master)

Package contains following validators: EmailValidator VatValidator

both throw exceptions if invalid data is given and does not throw any if data is valid

Vat validation is a beta feature for any issues or inconsistencies please contact me via nuget.org

Usage:

Call EmailValidator.Activate(<your e-mail>,<your key>) or VatValidator.Activate(<your e-mail>,<your key>) to be able to use validation, get your free key useable for any other igrok-net products from https://igrok-net.org/keys
