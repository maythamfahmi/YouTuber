<a href="https://github.com/maythamfahmi/YouTuber/blob/master/LICENSE.txt">
<img 
    style="display: block; margin-left: auto; margin-right: auto; height: 140px; width: 140px;"
    src="https://github.com/maythamfahmi/YouTuber/blob/master/logo.png" 
    alt="YouTuber logo">
</img>
</a>

# YouTuber

[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/maythamfahmi/YouTuber/blob/master/LICENSE.txt)
[![GitHub commits since latest release (by SemVer including pre-releases)](https://img.shields.io/github/commits-since/maythamfahmi/youtuber/v2.0.1?include_prereleases)](https://github.com/maythamfahmi/YouTuber/releases/tag/v2.0.1)

## Introdution
:rocket: **YouTuber** is a fast command line for downloading YouTube videos. 
**YoutTuber** is a cross platform (Windows and Ubuntu) Open Source software licensed under MIT License.
It is highly encouraged to read and respect [YouTube][1] policy and other content creators and owners copyright.

## Download and install
You can find downloadyoutube.zip and download **YouTuber** via [Releases](https://github.com/maythamfahmi/YouTuber/releases).

Extract the zip file and extract the version that fits your operating system. Follow the examples below under **How to use**.

Avaibale versions:
- DownloadYouTube-Win32.exe for Windows 10, 11
- DownloadYouTube-Win64.exe for Windows 10, 11
- DownloadYouTube-Linux64 for Linux 64

## How to use

### Example 1, Help
```./DownloadYouTube -h```

Result

```
[-h | --help]        Get help
[-d | --dummy]       Download sample files
[-l | --list]        Download directly, use ';' as seperator for multiple urls/Ids
example: -l https://www.youtube.com/watch?v=Kv3RfdHZ25c
example: -l Kv3RfdHZ25c;dVsZm7_sqfw;3rJfBFamlIw
[download.txt]       Create your own list
```

### Example 2, Download a single video based on youtube url
```./DownloadYouTube -l https://www.youtube.com/watch?v=Kv3RfdHZ25c```

It will download following link:

```
https://www.youtube.com/watch?v=Kv3RfdHZ25c
```

### Example 3 Download multiple videos based on youtube video id
```./DownloadYouTube -l y9ajRIgTJNA;pYlYt9iuJdc;NcumhqTDPpE```

It will download 3 youtube videos of following link:

```
https://www.youtube.com/watch?v=Kv3RfdHZ25c
https://www.youtube.com/watch?v=dVsZm7_sqfw
https://www.youtube.com/watch?v=3rJfBFamlIw
```

### Example 4 Download multiple videos based on youtube video url
```./DownloadYouTube -d```

It will download 3 samples videos. It will create download.txt list file of the 3 videos (You can add your own videos).

## Website

https://github.com/maythamfahmi/YouTuber

## Versions

#### [![Release%20Code](https://img.shields.io/badge/release%20code-v2.0.1-blue?style=social)](https://github.com/maythamfahmi/YouTuber/releases/tag/v2.0.1)
- Net 6
- Standard 2.0
- Documentation improvement

#### [![Release%20Code](https://img.shields.io/badge/release%20code-1.0.1-blue?style=social)](https://github.com/maythamfahmi/YouTuber/releases/tag/1.0.1)

<be />
<be />
<hr />
<be />
<be />

## Developer

### How to start
- git clone https://github.com/maythamfahmi/YouTuber
- dotnet build
- cd YouTuber.Cmd
- dotnet run

#### OS target
- Tested on Windows 10 and 11
- Ubuntu 20.xx
#### Language
- C# Sharp
- Standard 2
- Dotnet 6
#### 3rd party dependency
Third party packages/libraries:
- VideoLibrary

## Create Release
From you console:

After merging to master, create tag release:

```
git tag v2.x.x -a -m "Release description"
git push --tags
```

For pre-release, just tag with ```-pre``` like ```v2.x.x-pre```.

Rememebr to update readme badge and versions.

## Issues

Please report issues [here](https://github.com/maythamfahmi/YouTuber/issues).

## Contributing

I need your help, so if you have good knowledge of C# and Cryptography just grab one of the issues and add a pull request.
The same is valid, if you have idea for improvement, adding new feature or even documentation improvement and enhancemnet, you are more than welcome to contribute.

### How to contribute:

[Here](https://www.dataschool.io/how-to-contribute-on-github/) is a link to learn how to contribute if you are not a ware of how to do it.


[1]: http://youtube.com
