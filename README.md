[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://github.com/samuel-lucas6/PADME.NET/blob/main/LICENSE)

# PADMÉ.NET
A .NET implementation of [PADMÉ](https://petsymposium.org/2019/files/papers/issue4/popets-2019-0056.pdf) padding, which limits information leakage about the length of the plaintext for a wide range of encrypted data sizes.

## Installation
### NuGet
You can find the NuGet package [here](https://www.nuget.org/packages/PADME).

The easiest way to install this is via the NuGet Package Manager in [Visual Studio](https://visualstudio.microsoft.com/vs/), as explained [here](https://docs.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio). [JetBrains Rider](https://www.jetbrains.com/rider/) also has a package manager, and instructions can be found [here](https://www.jetbrains.com/help/rider/Using_NuGet.html).

### Manual
1. Download the latest [release](https://github.com/samuel-lucas6/PADME.NET/releases/latest).
2. Move the downloaded `.dll` file into your project folder.
3. Click on the `Project` tab and `Add Project Reference...` in Visual Studio.
4. Go to `Browse`, click the `Browse` button, and select the downloaded `.dll` file.
5. Add `using Padme;` to the top of each code file that needs the library.

## Usage
Here is an example of Pad-then-Encrypt using PADMÉ with ISO/IEC 7816-4 padding, which can be easily removed after decryption:

```c#
// Get the amount of padding to add
int paddingLength = PADME.GetPaddingLength(message.Length);

// Apply ISO/IEC 7816-4 padding
byte[] paddedMessage = Padding.Apply(message, paddingLength);

// Encrypt the padded plaintext using an AEAD
byte[] ciphertext = XChaCha20BLAKE2b.Encrypt(paddedMessage, nonce, key);

// Decrypt the ciphertext
byte[] paddedPlaintext = XChaCha20BLAKE2b.Decrypt(ciphertext, nonce, key);

// Remove the padding
byte[] plaintext = Padding.Remove(paddedPlaintext);
```
