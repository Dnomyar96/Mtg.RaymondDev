using Mtg.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtg.Data.Models
{
    public class Card
    {
        public Card()
        {
            Names = new List<string>();
            Colors = new List<string>();
            ColorIdentity = new List<string>();
            SuperTypes = new List<string>();
            Types = new List<string>();
            SubTypes = new List<string>();
            Variations = new List<int>();
            Rulings = new List<Ruling>();
            ForeignNames = new List<ForeignName>();
            Printings = new List<string>();
            Legalities = new List<Legality>();
            Collections = new List<CollectionCard>();
        }

        public int Id { get; set; }

        /// <summary>
        /// A unique id for this card. It is made up by doing an SHA1 hash of setCode + cardName + cardImageName
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// The card layout. Possible values: normal, split, flip, double-faced, token, plane, scheme, phenomenon, leveler, 
        /// vanguard, meld
        /// </summary>
        public string Layout { get; set; }

        /// <summary>
        /// The card name. For split, double-faced and flip cards, just the name of one side of the card. Basically each 
        /// 'sub-card' has its own record.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Only used for split, flip, double-faced, and meld cards. Will contain all the names on this card, front or back. 
        /// For meld cards, the first name is the card with the meld ability, which has the top half on its back, the second 
        /// name is the card with the reminder text, and the third name is the melded back face.
        /// </summary>
        public virtual ICollection<string> Names { get; set; }

        /// <summary>
        /// The mana cost of this card. Consists of one or more mana symbols.
        /// </summary>
        public string ManaCost { get; set; }

        /// <summary>
        /// Converted mana cost. Always a number. NOTE: cmc may have a decimal point as cards from unhinged may contain 
        /// "half mana" (such as 'Little Girl' with a cmc of 0.5). Cards without this field have an implied cmc of zero 
        /// as per rule 202.3a
        /// </summary>
        public decimal Cmc { get; set; }

        /// <summary>
        /// The card colors. Usually this is derived from the casting cost, but some cards are special (like the back 
        /// of double-faced cards and Ghostfire).
        /// </summary>
        public virtual ICollection<string> Colors { get; set; }

        /// <summary>
        /// This is created reading all card color information and costs. It is the same for double-sided cards (if 
        /// they have different colors, the identity will have both colors). It also identifies all mana symbols in 
        /// the card (cost and text). Mostly used on commander decks.
        /// </summary>
        public virtual ICollection<string> ColorIdentity { get; set; }

        /// <summary>
        /// The card type. This is the type you would see on the card if printed today. Note: The dash is a UTF8
        /// 'long dash' as per the MTG rules
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The supertypes of the card. These appear to the far left of the card type. Example values: Basic, 
        /// Legendary, Snow, World, Ongoing
        /// </summary>
        public virtual ICollection<string> SuperTypes { get; set; }

        /// <summary>
        /// The types of the card. These appear to the left of the dash in a card type. Example values: Instant, 
        /// Sorcery, Artifact, Creature, Enchantment, Land, Planeswalker
        /// </summary>
        public virtual ICollection<string> Types { get; set; }

        /// <summary>
        /// The subtypes of the card. These appear to the right of the dash in a card type. Usually each 
        /// word is its own subtype. Example values: Trap, Arcane, Equipment, Aura, Human, Rat, Squirrel, etc.
        /// </summary>
        public virtual ICollection<string> SubTypes { get; set; }

        /// <summary>
        /// The rarity of the card. Examples: Common, Uncommon, Rare, Mythic Rare, Special, Basic Land
        /// </summary>
        public string Rarity { get; set; }

        /// <summary>
        /// The text of the card. May contain mana symbols and other symbols.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The flavor text of the card.
        /// </summary>
        public string Flavor { get; set; }

        /// <summary>
        /// The artist of the card. This may not match what is on the card as MTGJSON corrects many card misprints.
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        /// The card number. This is printed at the bottom-center of the card in small text. This is a string, not an integer, because some cards have letters in their numbers.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// The power of the card. This is only present for creatures. This is a string, not an integer, because some cards have powers like: "1+*"
        /// </summary>
        public string Power { get; set; }

        /// <summary>
        /// The toughness of the card. This is only present for creatures. This is a string, not an integer, because some cards have toughness like: "1+*"
        /// </summary>
        public string Toughness { get; set; }

        /// <summary>
        /// The loyalty of the card. This is only present for planeswalkers.
        /// </summary>
        public int? Loyalty { get; set; }

        /// <summary>
        /// The multiverseid of the card on Wizard's Gatherer web page.
        /// Cards from sets that do not exist on Gatherer will NOT have a multiverseid.
        /// Sets not on Gatherer are: ATH, ITP, DKM, RQS, DPA and all sets with a 4 letter code that starts with a lowercase 'p'.
        /// </summary>
        public int MultiverseId { get; set; }

        /// <summary>
        /// If a card has alternate art (for example, 4 different Forests, or the 2 Brothers Yamazaki) then each 
        /// other variation's multiverseid will be listed here, NOT including the current card's multiverseid. 
        /// NOTE: Only present for sets that exist on Gatherer.
        /// </summary>
        public virtual ICollection<int> Variations { get; set; }

        /// <summary>
        /// This used to refer to the mtgimage.com file name for this card.
        /// mtgimage.com has been SHUT DOWN by Wizards of the Coast.
        /// This field will continue to be set correctly and is now only useful for UID purposes.
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// The watermark on the card. Note: Split cards don't currently have this field set, despite having a watermark on 
        /// each side of the split card.
        /// </summary>
        public string WaterMark { get; set; }

        /// <summary>
        /// If the border for this specific card is DIFFERENT than the border specified in the top level set JSON, then 
        /// it will be specified here. (Example: Unglued has silver borders, except for the lands which are black bordered)
        /// </summary>
        public Border Border { get; set; }

        /// <summary>
        /// If this card was a timeshifted card in the set.
        /// </summary>
        public bool TimeShifted { get; set; }

        /// <summary>
        /// Maximum hand size modifier. Only exists for Vanguard cards.
        /// </summary>
        public int Hand { get; set; }

        /// <summary>
        /// Starting life total modifier. Only exists for Vanguard cards.
        /// </summary>
        public int Life { get; set; }

        /// <summary>
        /// Set to true if this card is reserved by Wizards Official Reprint Policy
        /// </summary>
        public bool Reserved { get; set; }

        /// <summary>
        /// The date this card was released. This is only set for promo cards. The date may not be accurate to 
        /// an exact day and month, thus only a partial date may be set (YYYY-MM-DD or YYYY-MM or YYYY). Some 
        /// promo cards do not have a known release date.
        /// </summary>
        public string ReleaseDate { get; set; }

        /// <summary>
        /// Set to true if this card was only released as part of a core box set. These are technically part 
        /// of the core sets and are tournament legal despite not being available in boosters.
        /// </summary>
        public bool Starter { get; set; }

        /// <summary>
        /// Number used by MagicCards.info for their indexing URLs (Most often it is the card number in the set)
        /// </summary>
        public string MciNumber { get; set; }

        /// <summary>
        /// The rulings for the card. An array of objects, each object having 'date' and 'text' keys.
        /// </summary>
        public virtual ICollection<Ruling> Rulings { get; set; }

        /// <summary>
        /// Foreign language names for the card, if this card in this set was printed in another language. An array of
        /// objects, each object having 'language', 'name' and 'multiverseid' keys. Not available for all sets.
        /// </summary>
        public virtual ICollection<ForeignName> ForeignNames { get; set; }

        /// <summary>
        /// The sets that this card was printed in, expressed as an array of set codes.
        /// </summary>
        public virtual ICollection<string> Printings { get; set; }

        /// <summary>
        /// The original text on the card at the time it was printed. This field is not available for promo cards.
        /// </summary>
        public string OriginalText { get; set; }

        /// <summary>
        /// The original type on the card at the time it was printed. This field is not available for promo cards.
        /// </summary>
        public string OriginalType { get; set; }

        /// <summary>
        /// Which formats this card is legal, restricted or banned in. An array of objects, each object having
        /// 'format' and 'legality'. A 'condition' key may be added in the future if Gatherer decides to utilize it again.
        /// </summary>
        public virtual ICollection<Legality> Legalities { get; set; }

        /// <summary>
        /// For promo cards, this is where this card was originally obtained. For box sets that are theme decks,
        /// this is which theme deck the card is from. For clash packs, this is which deck it is from.
        /// </summary>
        public string Source { get; set; }

        public virtual ICollection<CollectionCard> Collections { get; set; }
    }
}
