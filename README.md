# PADMÉ.NET
A .NET implementation of [PADMÉ](https://petsymposium.org/2019/files/papers/issue4/popets-2019-0056.pdf) padding, which limits information leakage about the length of the plaintext for a wide range of encrypted data sizes.

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
