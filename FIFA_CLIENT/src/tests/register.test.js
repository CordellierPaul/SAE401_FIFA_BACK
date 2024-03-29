import { expect, test } from "vitest"
import { conditionsSontVerifieesPourMotDePasse } from "../pages/register.vue"

const motsDePassesPasBon = [
    "ifejz8894984894-!dziof",   // sans caractère majuscule
    "ZEAI44546412OUJZF/5!",     // sans caractère minuscule
    "ifejzi78797DSQSFFEfof",    // sans caractère spécial
    "ifejz---*dqdzeadHGHUGiof", // sans chiffre
    "ifejziof",         // moins de 12 caractères
    "azeifhfOJKFIOE"    // un dernier
]

motsDePassesPasBon.forEach(motDePassePasBon => {
    test("test vérification pour le mot de passe : " + motDePassePasBon, () => {
        expect(conditionsSontVerifieesPourMotDePasse(motDePassePasBon)).toBe(false)
    })
});

const motsDePassesAdaptes = [
    "+hIUQSDHkklsq5",
    "ZEAI445a2OUJZF/5!",
    "ifejzi7DS@FEfof"
]

motsDePassesAdaptes.forEach(motDePasseAdapte => {
    test("test vérification pour le mot de passe : " + motDePasseAdapte, () => {
        expect(conditionsSontVerifieesPourMotDePasse(motDePasseAdapte)).toBe(true)
    })
});