# YouTuber

[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/maythamfahmi/YouTuber/blob/main/LICENSE.txt)
[![GitHub commits since latest release (by SemVer including pre-releases)](https://img.shields.io/github/commits-since/maythamfahmi/youtuber/v2.0.4?include_prereleases)](https://github.com/maythamfahmi/YouTuber/releases/tag/v2.0.4)

## Introdution
📢 **YouTuber** is a fast command line for downloading YouTube videos. 
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

#### [![Release%20Code](https://img.shields.io/badge/release%20code-v2.0.4-blue?style=social)](https://github.com/maythamfahmi/YouTuber/releases/tag/v2.0.4)
- Net 6
- Standard 2.0
- Documentation improvement

#### [![Release%20Code](https://img.shields.io/badge/release%20code-1.0.1-blue?style=social)](https://github.com/maythamfahmi/YouTuber/releases/tag/1.0.1)

[1]: http://youtube.com
