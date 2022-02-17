# YouTuber

<a href="https://github.com/maythamfahmi/wet-extractor/blob/master/LICENSE">
    <img src="https://github.com/maythamfahmi/YouTuber/blob/master/logo.png" align="right" height="140" width="140" >
</a>

[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/maythamfahmi/YouTuber/blob/master/LICENSE)
[![GitHub commits since latest release (by SemVer including pre-releases)](https://img.shields.io/github/commits-since/maythamfahmi/youtuber/v2.0.0-beta.0?include_prereleases)](https://github.com/maythamfahmi/YouTuber/releases/tag/v2.0.0-beta.0)


# Introdution
:rocket: Youtuber is a little command line software for downloading own youtube content. 
It is highly encouraged to read and respect [YouTube][1] policy and content owner copyright.
You are welcome to continue improving it for learning purpose.
The software is license under MIT license agreement.

## Installation

You can download YouTuber via [Releases](https://github.com/maythamfahmi/YouTuber/releases).

## Website

https://github.com/maythamfahmi/YouTuber

## Versions

#### [![Release%20Code](https://img.shields.io/badge/release%20code-v2.0.0_beta.0-blue?style=social)](https://github.com/maythamfahmi/YouTuber/releases/tag/v2.0.0-beta.0)
- Net 6
- Standard 2.0
- Documentation improvement

#### [![Release%20Code](https://img.shields.io/badge/release%20code-1.0.1-blue?style=social)](https://github.com/maythamfahmi/YouTuber/releases/tag/1.0.1)


### Developer

#### How to start
- Clone
- Build
- Start Cmd project

#### OS target
- Tested on Windows 10/11
#### Language
- C# Sharp
- Standard 2
- Dotnet 6
#### 3rd party dependency
Third party packages/libraries:
- VideoLibrary

## Issues

Please report issues [here](https://github.com/maythamfahmi/YouTuber/issues).

## How to use

### Example 1, Help
Run following command to get help

```DownloadYouTube.exe -h```

```
[-h | --help]        Get help
[-d | --dummy]       Download sample files
[-l | --list]        Download directly, use ';' as seperator for multiple urls/Ids
example: -l https://www.youtube.com/watch?v=Kv3RfdHZ25c
example: -l Kv3RfdHZ25c;dVsZm7_sqfw;3rJfBFamlIw
[download.txt]       Create your own list
```

### Example 2, Download a single video based on youtube url
Run following command to download 1 video

```DownloadYouTube.exe -l https://www.youtube.com/watch?v=Kv3RfdHZ25c```

It will download following link:

```
https://www.youtube.com/watch?v=Kv3RfdHZ25c
```

### Example 2 Download multiple videos based on youtube video id
Run following command to download 3 videos

```DownloadYouTube.exe -l y9ajRIgTJNA;pYlYt9iuJdc;NcumhqTDPpE```

It will download 3 youtube videos of following link:

```
https://www.youtube.com/watch?v=Kv3RfdHZ25c
https://www.youtube.com/watch?v=dVsZm7_sqfw
https://www.youtube.com/watch?v=3rJfBFamlIw
```

### Example 2 Download multiple videos based on youtube video url
Run following command to download 3 samples videos. It will create download.txt list file of the 3 videos (You can add your own videos).

```DownloadYouTube.exe -d```

It will download video from download.txt



## Contributing

I need your help, so if you have good knowledge of C# and Cryptography just grab one of the issues and add a pull request.
The same is valid, if you have idea for improvement, adding new feature or even documentation improvement and enhancemnet, you are more than welcome to contribute.

### How to contribute:

[Here](https://www.dataschool.io/how-to-contribute-on-github/) is a link to learn how to contribute if you are not a ware of how to do it.


[1]: http://youtube.com