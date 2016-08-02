//ADD A NEW BLOCK ON THE FORM
function addBlock() {
    var blockList = $('.blocks'),
       blockModel = $('.blockModel:first'),
       newEntry = $(blockModel.clone()).appendTo(blockList);
    newEntry;
    blockList.find('.panel:not(:first) .btn-trash')
        .removeClass('disabled');
    blockList.find('.blockModel').removeClass("hidden");
}

//ADD A QUESTION TO THE CURRENT BLOCK
//TITLE IS THE QUESTION TITLE
function addQuestion(currentObject, title) {
    var questionModel = $(".questionModel:first");
    var isMainQuestion = $(currentObject).hasClass('mainQuestion');
    if (isMainQuestion) {
        var buttonParent = $(currentObject).parents('.panel:first'),
        questionList = $(buttonParent).find('ul:first'),
        newQuestion = questionModel.clone(),
        addTitle = newQuestion.find(".inputQuestion:first").val(title),
        addQuestion = (questionList).find("li:first").after(newQuestion);
        questionList.find('li')
                    .removeClass("hidden");

    }
    else {
        var currentQuestion = $(currentObject).parents('li:first'),
            questionList = $(currentObject).parents('ul:first'),
            newQuestion = $(currentQuestion).after(questionModel.clone()),
            addTitle = newQuestion.find(".inputQuestion:first").val(title);
        questionList.find('li')
            .removeClass("hidden");
    }
}

//CURRENTOBJECT IS A SELECT ITEM FOR CHOOSING QUESTION TYPE
function ShowHidePossibleAnswer(currentObject) {
    if ($(currentObject).val() == 1) {
        $(currentObject).parents('.typeQuestion:first').find('.listAnswer').addClass('hidden');
    }
    else {
        $(currentObject).parents('.typeQuestion:first').find('.listAnswer').removeClass('hidden')
    }
}

//ADD A POSSIBLE ANSWER FOR THE CURRENT QUESTION
//TITLE IS THE POSSIBLE ANSWER TITLE
function addPossibleAnswer(currentObject, title) {
    var answerList = $(currentObject).parents('.listAnswer'),
    answerModel = $(currentObject).parents('.modelAnswer'),
    addAnswer = $(answerModel.clone()).appendTo(answerList);
    addAnswer.find("input").val(title);
    answerList.find('.input-group:not(:last) .btn-addAnswer')
        .removeClass('btn-addAnswer').addClass('btn-removeAnswer')
        .removeClass('btn-success').addClass('btn-danger')
        .html('<span class="glyphicon glyphicon-minus"></span>');
}


//ADD IDs TO ALL BLOCKS, QUESTION, ANSWER..
function ajoutId() {
    var nbBlocks = $('.blockModel').not(".hidden").length;
    var listBlock = $('.blocks');
    for (var i = 0; i < nbBlocks; i++) {
        var block = listBlock.find('.blockModel#block:first');
        var changeInputBlockName = block
                                        .find("[name='Block[].Id']:first")
                                        .attr("name", "Block[" + i + "].Id")
        var changeBlockId = block.attr("id", "block" + i);

        var nbQuestion = block.find(".inputQuestion").length;
        for (var j = 0 ; j < nbQuestion ; j++) {
            var question = block.find('.inputQuestion[name="Block[].Question[].Title"]:first');
            question.attr("name", "Block[" + i + "].Question[" + j + "].Title");
            block.find("[name='Block[].Question[].Type']:first")
                .attr("name", "Block[" + i + "].Question[" + j + "].Type");

            var currentQuestion = block.find("#question:first");
            var possibleAnswers = currentQuestion.find(".possibleAnswer");

            var nbRepPossible = 0;
            $.each(possibleAnswers, function (index, value) {
                if ($(this).val() != "") {
                    $(this).attr("name", "Block[" + i + "].Question[" + j + "].PossibleAnswer[" + nbRepPossible + "].Title")
                    nbRepPossible++;
                }
            });
            currentQuestion.attr("id", "questionModified");
        }
    }

    $("#DateCreation").attr("value", Date.now());
    return false;
};


$(function () {

    //BUTTON ADD/DELETE A BLOCK OF QUESTIONS
    $(document).on('click', '#addBlock', function (e) {
        e.preventDefault();
        addBlock()
    }).on('click', '.btn-trash', function (e) {
        $(this).parents('.panel:first').remove();
        e.preventDefault();
        return false;
    });

    //BUTTON ADD/DELETE A QUESTION
    $(document).on('click', ".btn-addQuestion", function (e) {
        e.preventDefault();
        addQuestion(this);
    }).on('click', ".btn-delQuestion", function (e) { //DELETE CURRENT QUESTION
        $(this).parents('.questionModel:first').remove();
        e.preventDefault();
        return false;
    });

    //DISPLAY POSSIBLEANSWER OPTIONS DEPEND ON THE TYPE
    $(document).on('change', 'select', function (e) {
        e.preventDefault();
        ShowHidePossibleAnswer(this);
    });

    //BUTTON ADD/DELETE A POSSIBLE ANSWER
    $(document).on('click', '.btn-addAnswer', function (e) {
        e.preventDefault();
        addPossibleAnswer(this);
    }).on('click', '.btn-removeAnswer', function (e) {
        $(this).parents('.modelAnswer:first').remove();
        e.preventDefault();
        return false;
    });

    //ADD ALL CORRECT NAMES TO SUBMIT A FORMVIEWMODEL OBJECT
    $('#AjoutId').click(function (e) {
        ajoutId();
        e.preventDefault();
        return false;
    });

    //SUBMIT THE FORM
    $('#creer').click(function (e) {
        var form = $(this).closest('form');
        ajoutId();
        $("#formForm").submit();
        e.preventDefault();
        return false;
    });

    //GENERATE THE FORM MODEL
    $(document).ready(function () {
        alert(jsonMoche);
        $.each(model.Block, function (i, blockVal) {
            addBlock();
            $.each(blockVal.Question, function (j, questionVal) {
                if (j == 0) {
                    $(".inputQuestion:last").val(questionVal.Title);
                }
                else {
                    addQuestion($(".btn-addQuestion:last"), questionVal.Title);
                }
                $("select:last").val(questionVal.Type);
                ShowHidePossibleAnswer($("select:last"));
                $.each(questionVal.PossibleAnswer, function (k, possibleAnswVal) {
                    if (k == 0) {
                        $(".possibleAnswer:last").val(possibleAnswVal.Title)
                    }
                    else {
                        addPossibleAnswer(".btn-addAnswer:last", possibleAnswVal.Title);
                    }
                });
            });
        });
    });




});

