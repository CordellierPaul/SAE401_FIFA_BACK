import sha256 from 'crypto-js/sha512';
import Base64 from 'crypto-js/enc-base64';

export function encrypter(motDePasse) {
    let encyption = sha256(motDePasse)
    return encyption.toString(Base64)
}

export function verifierMotDePasse(motDePasseEnClair, motDePasseEncrypte) {
    let encyption = sha256(motDePasseEnClair).toString(Base64)
    return encyption === motDePasseEncrypte
}