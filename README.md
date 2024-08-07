# The Caspian Sea Monster

usfule links:
- [awesome](https://github.com/aloisdeniel/awesome-monogame?tab=readme-ov-file)

## Trubleshout
### Mac OS
#### fail to build on M1 Chip
go to
```sh
cd /Users/samuelsayag/.nuget/packages/monogame.content.builder.task/<version>/build

nano MonoGame.Content.Builder.Task.props
```

update line 144 to (remove dotnet command):
```xml
<Exec
      Condition="'%(ContentReference.FullPath)' != ''"
      Command="$(MGCBCommand) $(MonoGameMGCBAdditionalArguments) /@:&quot;%(ContentReference.FullPath)&quot; /platform:$(MonoGamePlatform) /outputDir:&quot;%(ContentReference.ContentOutputDir)&quot; /intermediateDir:&quot;%(ContentReference.ContentIntermediateOutputDir)&quot; /workingDir:&quot;%(ContentReference.FullDir)&quot;"
      WorkingDirectory="$(MSBuildProjectDirectory)" />

```