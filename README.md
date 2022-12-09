AppSeal
=======

A little helper program to seal / sign windows applications (.exe and .msi).
Installs a "Send To" shortcut in your profile.


Configuration
=============

Place a configuration file such as the following in your Documents folder.
Configuration file name is AppSeal.json.

Content:

```json
{
	"SignTool": "{full path to sign tool - remember to escape backslashes, eample: C:\\Program Files (x86)\\Microsoft SDKs\\ClickOnce\\SignTool\\signtool.exe}",
	"SealProfiles": [
		{
			"Name": "{name of profile - shown in dropdown}",
			"Thumbprint": "{seal certificate thumbprint}",
			"TimeStampUrl": "{timestamp server url such as http://timestamp.globalsign.com/tsa/r6advanced1}",
			"TimeStampHash": "{timestamp hash method such as SHA256}",
			"Description": "{description of signed binary such as the product name}",
			"DescriptionUrl": "{url to fuller description}"
		}
	]
}
```


Create setup file
=================

Requirements:

* [Inno Setup](https://jrsoftware.org/isinfo.php) must be installed and in your path.
* `C:\Temp` must be present - this is where the output installer will be placed

Howto:

1. Launch Command Line
2. Navigte to AppSeal root folder
3. `iscc setup.iss`

