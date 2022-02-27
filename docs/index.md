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
You can find downloadyoutube.7z and download **YouTuber** via [Releases](https://github.com/maythamfahmi/YouTuber/releases).

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

[List of improvement](https://github.com/maythamfahmi/YouTuber/issues?q=is%3Aissue+is%3Aclosed)
