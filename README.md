# DirInfo
This application allows its users to find out which folders and files are contained in a specified directory.

Hidden folders/files contain the `[Hidden]` prefix.

Users are also given the possibility of creating new directories.

# Exception handling
If the user tries to create a new directory (ex. in `C:\Windows\`) without necessary privileges, the following exception will be thrown: `Access to path 'C:\Windows\Directory' is denied`.

![exception-handling-example](../main/Directory_Exception.png?raw=true)

# Application examples

![before-new-dir](../main/Before_NewDir.png?raw=true)

![new-dir-creation](../main/NewDir.png?raw=true)

![after-new-dir](../main/After_NewDir.png?raw=true)
