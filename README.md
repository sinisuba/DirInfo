# DirInfo
This application allows its users to find out which folders and files are contained in a specified directory.

Hidden folders/files contain the `[Hidden]` prefix.

Users are also given the possibility of creating new directories.

# Exception handling examples
`UnauthorizedAccessException` – if the user attempts to create a new directory without necessary privileges (e.g. in `C:\Windows\`), the following exception will be thrown: `Access to path 'C:\Windows\Directory' is denied`.

![exception-handling-UnauthorizedAccessException](../main/UnauthorizedAccessException.png?raw=true)

`DirectoryNotFoundException` – if the user specifies an invalid path (e.g. `F:\TestDir\...`), the following exception will be thrown: `Could not find a part of the path 'F:\TestDir\...\SubDir\`.

![exception-handling-DirectoryNotFoundException](../main/DirectoryNotFoundException.png?raw=true)

Some other exceptions include `IOException`, `ArgumentException`, `ArgumentNullException`, `PathTooLongException`, `NotSupportedException`.

# Application examples

![before-new-dir](../main/Before_NewDir.png?raw=true)

![new-dir-creation](../main/NewDir.png?raw=true)

![after-new-dir](../main/After_NewDir.png?raw=true)
