### MU3Input `MU3Input.sln`
#### IO library to use with segatools

# Thanks GEEKiDoS

Usage: 
- Copy `MU3Input.dll` into game folder
- Open segatools.ini and add following lines:
```ini
[mu3io]
path=MU3Input.dll

[aimeio]
path=MU3Input.dll
```

You can use Jetbrains Rider or Visual Studio to compile.


### mu3controller `mu3controller\ `
#### Arduino Leonardo firmware to use with above IO library.

I Move the project to Arduino so you can use Arduino upload it not the Visual Studio.
