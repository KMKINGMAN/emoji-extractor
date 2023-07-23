
# Emoji Extractor

The Emoji Extractor is a command-line tool written in C# that allows users to extract unique emoji codes from a given text file. The tool is designed to work with files that contain text, such as Discord message logs or any other text-based files containing emojis. It uses regular expressions to find emoji codes in the file content and downloads the corresponding emoji images from Discord's CDN. The downloaded emoji images are then saved to a specified folder.

### Features

- **Emoji Code Extraction**: The tool searches for emoji codes in the provided text file using regular expressions. It captures both animated and non-animated emoji codes, represented in the format `<:emoji_name:emoji_id>` or `<a:emoji_name:emoji_id>`.

- **Unique Emoji Codes**: The Emoji Extractor ensures that only unique emoji codes are extracted from the file. If an emoji code is already extracted, it will not be duplicated in the output.

- **Downloading Emoji Images**: Once the unique emoji codes are extracted, the tool constructs URLs to the corresponding emoji images hosted on Discord's CDN. It downloads the emoji images using the .NET `WebClient` class and saves them to a specified folder on the local machine.

### Getting Started

To use the Emoji Extractor, you need to have the .NET SDK installed on your machine. The tool is written in C# and built using .NET Core.

#### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download): Make sure you have the .NET SDK installed on your machine before running the Emoji Extractor.

#### Installation

1. Clone the Emoji Extractor repository from GitHub to your local machine.

```
git clone https://github.com/kmkingman/emoji-extractor.git
cd emoji-extractor
```

### Usage

To extract emoji codes from a text file, open a terminal or command prompt and navigate to the root directory of the project.

The basic command to run the Emoji Extractor is:

```
dotnet run <filePath>
```

Replace `<filePath>` with the path to the text file from which you want to extract emoji codes.

**Example:**

```
dotnet run ./sample_file.txt
```

This command will extract unique emoji codes from the `sample_file.txt` and save the corresponding emoji images to the `./kingman` folder.

### Command-Line Options

The Emoji Extractor supports the following command-line options:

- `--help` or `-h`: Display the help message, showing how to use the tool and available options.

```
dotnet run --help
```

- `--version`: Display the version of the Emoji Extractor tool.

```
dotnet run --version
```

### License

This project is licensed under the Boost Software License 1.0. See the [LICENSE](LICENSE) file for details.


---
