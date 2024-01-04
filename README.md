# YouTuber

[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/maythamfahmi/YouTuber/blob/main/LICENSE.txt)
[![GitHub commits since latest release (by date including pre-releases)](https://img.shields.io/github/commits-since/maythamfahmi/youtuber/latest?include_prereleases)](https://github.com/maythamfahmi/YouTuber/releases/latest)
[![.NET-CI](https://github.com/maythamfahmi/YouTuber/actions/workflows/ci.yml/badge.svg)](https://github.com/maythamfahmi/YouTuber/actions/workflows/ci.yml)
[![Release](https://github.com/maythamfahmi/YouTuber/actions/workflows/windows-release.yml/badge.svg)](https://github.com/maythamfahmi/YouTuber/actions/workflows/windows-release.yml)

## Introduction
:rocket: **YouTuber** is a fast command line for downloading YouTube videos. 
**YouTuber** is a cross-platform (Windows and Ubuntu) Open Source software licensed under MIT License.
It is highly encouraged to read and respect [YouTube][1] policy and other content creators' and owners' copyrights.

## Download and install
You can find downloadyoutube.7z and download **YouTuber** via [Releases](https://github.com/maythamfahmi/YouTuber/releases).

Extract the zip file and extract the version that fits your operating system. Follow the examples below under **How to use**.

Available versions:
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

  -l, --list     Required. Download single or multiple youtube by url or id, use ; as separator.
                 DownloadYouTube -l xxxxxxxxxxx;xxxxxxxxxxx;xxxxxxxxxxx
                 DownloadYouTube -l xxxxxxxxxxx
                 DownloadYouTube -l dummy will download 3 preselected videos using download.txt file, for demo purpose.

  --help         Display this help screen.

  --version      Display version information.
```

### Example 2, Download a single video based on youtube url
```./DownloadYouTube -l https://www.youtube.com/watch?v=Kv3RfdHZ25c```

It will download the following link:

```
https://www.youtube.com/watch?v=Kv3RfdHZ25c
```

### Example 3 Download multiple videos based on YouTube video ID
```./DownloadYouTube -l Kv3RfdHZ25c;dVsZm7_sqfw;3rJfBFamlIw```

It will download 3 YouTube videos from the following link:

```
https://www.youtube.com/watch?v=Kv3RfdHZ25c
https://www.youtube.com/watch?v=dVsZm7_sqfw
https://www.youtube.com/watch?v=3rJfBFamlIw
```

### Example 4 Download multiple videos based on the YouTube video URL
```./DownloadYouTube -l dummy```

It will download 3 sample videos. It will create a download.txt list file of the 3 videos (You can add your own videos).

### Example 5 Download multiple videos based on the YouTube video URL
```./DownloadYouTube -l ./download.txt```

It will download whatever youtube link from the download.txt file.

### Example 6 Download and extract only Audio of the YouTube video
```./DownloadYouTube -l ./download.txt -a mp3```

Will convert to mp3

```./DownloadYouTube -l ./download.txt -a m4a```

Will convert to m4a

**Note**: Audio conversion might take longer time than downloading the video.

### Example 7 Download multiple videos of different variation
```./DownloadYouTube -l Kv3RfdHZ25c;https://www.youtube.com/watch?v=dVsZm7_sqfw;https://youtu.be/3rJfBFamlIw```

It will download 3 YouTube videos of the following link:

```           
https://www.youtube.com/watch?v=Kv3RfdHZ25c
https://www.youtube.com/watch?v=dVsZm7_sqfw
https://www.youtube.com/watch?v=3rJfBFamlIw
```

## Website

https://maythamfahmi.github.io/YouTuber

## Versions

![GitHub commits since latest release (by SemVer)](https://img.shields.io/github/commits-since/maythamfahmi/youtuber/latest?style=social)

[List of improvement](https://github.com/maythamfahmi/YouTuber/issues?q=is%3Aissue+is%3Aclosed)

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
- Dotnet 8
#### 3rd party dependency
Third-party packages/libraries:
- VideoLibrary
- Xabe.FFmpeg 
- Xabe.FFmpeg.Downloader
- CommandLineParser

Xabe is used for the audio conversion feature. It is only for none non-commercial use, else contact Xabe.FFmpeg

## Create Release
From your console:

After merging to the main, create a tag release:

```
git tag 3.x.x -a -m "Release version 3.x.x"
git push --tags
```

For pre-release, just tag with ```.0-pre``` like ```3.x.x.0-pre```.

Example:

```
git tag 3.x.x.0-pre -a -m "Release version 3.x.x.0-pre"
git push --tags
```

Or use the PowerShell command line Create Release.ps1 and it will automatically generate the next version, if you need to change the major or minor version, you need to pass the value manually.

**Note:** remove cached tags ```git fetch -p -P origin``` in case of mistake or clean up and ```git push --tags```

Remember to update the readme badge and versions.

### Testing with Ubuntu on Windows environment

```
docker run -it --rm -v $pwd`:/app mcr.microsoft.com/dotnet/sdk:6.0
cd /app
```

Example of testing release in Ubuntu docker instance:

```
dotnet publish /p:PublishProfile=Release-win-x64 -c Release
```

Check this https://github.com/dotnet/sdk/issues/23627

It requires a docker desktop.

## Issues

Known issue: You might experience slow downloads, which is normal. Just be patient.

Please report issues [here](https://github.com/maythamfahmi/YouTuber/issues).

## Contributing

I need your help, so if you have good knowledge of C# and Cryptography just grab one of the issues and add a pull request.
The same is valid, if you have ideas for improvement, adding new features, or even documentation improvement and enhancement, you are more than welcome to contribute.

### How to contribute:

[Here](https://www.dataschool.io/how-to-contribute-on-github/) is a link to learn how to contribute if you are not a ware of how to do it.


[1]: http://youtube.com
