<a href="https://github.com/maythamfahmi/YouTuber/blob/main/LICENSE.txt">
<img 
    style="display: block; margin-left: auto; margin-right: auto; height: 140px; width: 140px;"
    src="https://github.com/maythamfahmi/YouTuber/blob/main/logo.png" 
    alt="YouTuber logo">
</img>
</a>

# YouTuber

[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/maythamfahmi/YouTuber/blob/main/LICENSE.txt)
[![GitHub commits since latest release (by date including pre-releases)](https://img.shields.io/github/commits-since/maythamfahmi/youtuber/latest?include_prereleases)](https://github.com/maythamfahmi/YouTuber/releases/latest)
[![.NET-CI](https://github.com/maythamfahmi/YouTuber/actions/workflows/ci.yml/badge.svg)](https://github.com/maythamfahmi/YouTuber/actions/workflows/ci.yml)
[![Release](https://github.com/maythamfahmi/YouTuber/actions/workflows/windows-release.yml/badge.svg)](https://github.com/maythamfahmi/YouTuber/actions/workflows/windows-release.yml)

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
```./DownloadYouTube --help```

Result

```
  -a, --audio    Extract only audio. -a mp3 or -a m4a.

  -l, --list     Required. Download single or multiple youtube by url or id, use
                 ; as separator.
                 ./DownloadYouTube -l xxxxxxxxxxx;xxxxxxxxxxx;xxxxxxxxxxx
                 ./DownloadYouTube -l xxxxxxxxxxx

  --help         Display this help screen.

  --version      Display version information.
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
```./DownloadYouTube -l dummy```

It will download 3 samples videos. It will create download.txt list file of the 3 videos (You can add your own videos).

### Example 5 Download multiple videos based on youtube video url
```./DownloadYouTube -l ./download.txt```

It will download what ever youtube link from download.txt file.

### Example 6 Download and extract only Audio of the youtube video
```./DownloadYouTube -l ./download.txt -a mp3```

Will convert to mp3

```./DownloadYouTube -l ./download.txt -a m4a```

Will convert to m4a

**Note**: Audio conversion might take longer time than downloading the video.

## Website

https://maythamfahmi.github.io/YouTuber

## Versions

![GitHub commits since latest release (by SemVer)](https://img.shields.io/github/commits-since/maythamfahmi/youtuber/latest?style=social)

#### [![Release%20Code](https://img.shields.io/badge/release%20code-v2.5.6-blue?style=social)](https://github.com/maythamfahmi/YouTuber/releases/tag/v2.5.6)
- Fix Multiple Audio conversion [Bug #25](https://github.com/maythamfahmi/YouTuber/issues/25)
- Convert to m4a audio [Feature #26](https://github.com/maythamfahmi/YouTuber/issues/25)
- Extracting Audio feature mp3
- Adding release tool
- Support Mac OS
- Refactored to Net 6 and Standard 2.0
- Documentation improvement

#### [![Release%20Code](https://img.shields.io/badge/release%20code-1.0.1-blue?style=social)](https://github.com/maythamfahmi/YouTuber/releases/tag/1.0.1)
- Initial release

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
git tag 2.x.x -a -m "Release version 2.x.x"
git push --tags
```

For pre-release, just tag with ```.0-pre``` like ```v2.x.x.0-pre```.

Example:

```
git tag 2.x.x.0-pre -a -m "Release version 2.x.x.0-pre"
git push --tags
```

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
