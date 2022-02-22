<a href="https://github.com/maythamfahmi/YouTuber/blob/main/LICENSE.txt">
<img 
    style="display: block; margin-left: auto; margin-right: auto; height: 140px; width: 140px;"
    src="https://github.com/maythamfahmi/YouTuber/blob/main/logo.png" 
    alt="YouTuber logo">
</img>
</a>

# YouTuber

[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/maythamfahmi/YouTuber/blob/main/LICENSE.txt)
[![GitHub commits since latest release (by SemVer including pre-releases)](https://img.shields.io/github/commits-since/maythamfahmi/youtuber/v2.5.1?include_prereleases)](https://github.com/maythamfahmi/YouTuber/releases/tag/v2.5.1)

## Introdution
:rocket: **YouTuber** is a fast command line for downloading YouTube videos. 
**YoutTuber** is a cross platform (Windows and Ubuntu) Open Source software licensed under MIT License.
It is highly encouraged to read and respect [YouTube][1] policy and other content creators and owners copyright.

## Download and install
You can find downloadyoutube.zip and download **YouTuber** via [Releases](https://github.com/maythamfahmi/YouTuber/releases).

Extract the zip file and extract the version that fits your operating system. Follow the examples below under **How to use**.

Avaibale versions:
- DownloadYouTube.exe from win-x86 folder for Windows OS 10, 11
- DownloadYouTube.exe from win-x64 folder for Windows OS 10, 11 
- DownloadYouTube from linux-x64 folder for Ubuntu OS
- DownloadYouTube from osx-x64 folder for Mac OS

## How to use

### Example 1, Help
```./DownloadYouTube -h```

Result

```
[-h | --help]        Get help
[-d | --dummy]       Download sample files
[-l | --list]        Download directly, use ';' as separator for multiple urls/Ids

examples:
./DownloadYouTube -l https://www.youtube.com/watch?v=Kv3RfdHZ25c -> will download single video
./DownloadYouTube -l Kv3RfdHZ25c;dVsZm7_sqfw;3rJfBFamlIw -> will download 3 videos
./DownloadYouTube -d -> will create download.txt with 3 dummy videos and download them
./DownloadYouTube ./download.txt -> will download your own list
Note: Please read README.md for more info.
By using this App, you agree to be bound by the terms and conditions of this Agreement
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

### Example 5 Download multiple videos based on youtube video url
```./DownloadYouTube ./download.txt```

It will download what ever youtube link from download.txt file.

### Example 6 Download and extract only Audio of the youtube video
```./DownloadYouTube ./download.txt -a```

Just add ```-a``` at the end of the command line for any example above.

Note: Audio conversion might take longer time than downloading the video.

## Website

https://maythamfahmi.github.io/YouTuber

## Versions

#### [![Release%20Code](https://img.shields.io/badge/release%20code-v2.5.1-blue?style=social)](https://github.com/maythamfahmi/YouTuber/releases/tag/v2.5.1)
- Fix Multiple Audio conversion [Bug #25](https://github.com/maythamfahmi/YouTuber/issues/25)
- Adding release tool
- Documentation improvement

#### [![Release%20Code](https://img.shields.io/badge/release%20code-v2.2.0-blue?style=social)](https://github.com/maythamfahmi/YouTuber/releases/tag/v2.2.0)
- Extracting Audio feature
- Documentation improvement

#### [![Release%20Code](https://img.shields.io/badge/release%20code-v2.1.0-blue?style=social)](https://github.com/maythamfahmi/YouTuber/releases/tag/v2.1.0)
- Support Mac OS
- Refactoring
- Documentation improvement

#### [![Release%20Code](https://img.shields.io/badge/release%20code-v2.0.4-blue?style=social)](https://github.com/maythamfahmi/YouTuber/releases/tag/v2.0.4)
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
- Xabe.FFmpeg 
- Xabe.FFmpeg.Downloader

Xabe is used for audio convertion feature. It is only for none commerical use, else contact Xabe.FFmpeg

## Create Release
From you console:

After merging to main, create tag release:

```
git tag v2.x.x -a -m "Release description"
git push --tags
```

For pre-release, just tag with ```-pre``` like ```v2.x.x-pre```.

**Note:** remove cached tags ```git fetch -p -P origin``` in case of mistake or clean up and ```git push --tags```

Rememebr to update readme badge and versions.

### Testing with Ubuntu on Windows environment

```docker run -it --rm -v $pwd`:/app mcr.microsoft.com/dotnet/sdk:6.0```
```cd /app```

Example of testing release in Ubuntu docker instance:

```dotnet publish /p:PublishProfile=Release-win-x64 -c Release```

Check this https://github.com/dotnet/sdk/issues/23627

It requries docker desktop.

## Issues

Please report issues [here](https://github.com/maythamfahmi/YouTuber/issues).

## Contributing

I need your help, so if you have good knowledge of C# and Cryptography just grab one of the issues and add a pull request.
The same is valid, if you have idea for improvement, adding new feature or even documentation improvement and enhancemnet, you are more than welcome to contribute.

### How to contribute:

[Here](https://www.dataschool.io/how-to-contribute-on-github/) is a link to learn how to contribute if you are not a ware of how to do it.


[1]: http://youtube.com
