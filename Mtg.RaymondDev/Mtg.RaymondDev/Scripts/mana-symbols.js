
$(function () {
    $("body").children().each(function () {
        $(this).html($(this).html().replace(/{B}/g, "<span class='mana small sb'></span>"));
        $(this).html($(this).html().replace(/{U}/g, "<span class='mana small su'></span>"));
        $(this).html($(this).html().replace(/{G}/g, "<span class='mana small sg'></span>"));
        $(this).html($(this).html().replace(/{R}/g, "<span class='mana small sr'></span>"));
        $(this).html($(this).html().replace(/{W}/g, "<span class='mana small sw'></span>"));

        $(this).html($(this).html().replace(/{[1]}/g, "<span class='mana small s1'></span>"));
        $(this).html($(this).html().replace(/{[2]}/g, "<span class='mana small s2'></span>"));
        $(this).html($(this).html().replace(/{[3]}/g, "<span class='mana small s3'></span>"));
        $(this).html($(this).html().replace(/{[4]}/g, "<span class='mana small s4'></span>"));
        $(this).html($(this).html().replace(/{[5]}/g, "<span class='mana small s5'></span>"));
        $(this).html($(this).html().replace(/{[6]}/g, "<span class='mana small s6'></span>"));
        $(this).html($(this).html().replace(/{[7]}/g, "<span class='mana small s7'></span>"));
        $(this).html($(this).html().replace(/{[8]}/g, "<span class='mana small s8'></span>"));
        $(this).html($(this).html().replace(/{[9]}/g, "<span class='mana small s9'></span>"));
        $(this).html($(this).html().replace(/{[10]}/g, "<span class='mana small s10'></span>"));
        $(this).html($(this).html().replace(/{[0]}/g, "<span class='mana small s0'></span>"));
        $(this).html($(this).html().replace(/{X}/g, "<span class='mana small sx'></span>"));

        $(this).html($(this).html().replace(/{B\/U}/g, "<span class='mana small sur'></span>"));
        $(this).html($(this).html().replace(/{B\/G}/g, "<span class='mana small sbg'></span>"));
        $(this).html($(this).html().replace(/{B\/R}/g, "<span class='mana small sbr'></span>"));
        $(this).html($(this).html().replace(/{B\/W}/g, "<span class='mana small sbw'></span>"));
        $(this).html($(this).html().replace(/{U\/B}/g, "<span class='mana small sub'></span>"));
        $(this).html($(this).html().replace(/{U\/G}/g, "<span class='mana small sug'></span>"));
        $(this).html($(this).html().replace(/{U\/R}/g, "<span class='mana small sur'></span>"));
        $(this).html($(this).html().replace(/{U\/W}/g, "<span class='mana small suw'></span>"));
        $(this).html($(this).html().replace(/{G\/B}/g, "<span class='mana small sgb'></span>"));
        $(this).html($(this).html().replace(/{G\/U}/g, "<span class='mana small sgu'></span>"));
        $(this).html($(this).html().replace(/{G\/R}/g, "<span class='mana small sgr'></span>"));
        $(this).html($(this).html().replace(/{G\/W}/g, "<span class='mana small sgw'></span>"));
        $(this).html($(this).html().replace(/{R\/B}/g, "<span class='mana small srb'></span>"));
        $(this).html($(this).html().replace(/{R\/U}/g, "<span class='mana small sru'></span>"));
        $(this).html($(this).html().replace(/{R\/G}/g, "<span class='mana small srg'></span>"));
        $(this).html($(this).html().replace(/{R\/W}/g, "<span class='mana small srw'></span>"));
        $(this).html($(this).html().replace(/{W\/B}/g, "<span class='mana small swb'></span>"));
        $(this).html($(this).html().replace(/{W\/U}/g, "<span class='mana small swu'></span>"));
        $(this).html($(this).html().replace(/{W\/G}/g, "<span class='mana small swg'></span>"));
        $(this).html($(this).html().replace(/{W\/R}/g, "<span class='mana small swr'></span>"));
    });
});