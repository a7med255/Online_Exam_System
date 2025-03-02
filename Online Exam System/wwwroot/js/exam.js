$(document).ready(function () {
    $("#questionForm").submit(function (event) {
        event.preventDefault();

        let examData = {
            ExamId: $("input[name='ExamId']").val(),
            Answers: []
        };

        $("input[type='radio']:checked").each(function () {
            let questionId = $(this).closest(".card-body").find("input[type='hidden']").val();
            let userAnswer = $(this).val();

            examData.Answers.push({
                QuestionId: questionId,
                UserAnswerChoise: userAnswer
            });
        });

        $.ajax({
            url: "/Home/SubmitExam",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(examData),
            success: function (response) {
                displayResults(response);
            },
            error: function (xhr) {
                alert(xhr.responseText); // ❌ إذا كان الامتحان مكتمل، عرض رسالة منع الإعادة
            }
        });
    });

    function displayResults(data) {
        let resultContainer = $("#resultContainer");
        resultContainer.empty();

        let status = data.isPassed ?
            `<span class="text-success fw-bold">🎉 ناجح</span>` :
            `<span class="text-danger fw-bold">❌ راسب</span>`;

        let resultHtml = `
            <div class="alert alert-info">
                <h4>📊 نتيجة الامتحان</h4>
                <p>✅ الإجابات الصحيحة: <strong>${data.correctCount}</strong></p>
                <p>❌ الإجابات الخاطئة: <strong>${data.wrongCount}</strong></p>
                <p>🎯 النتيجة النهائية: <strong>${data.score.toFixed(2)}%</strong></p>
                <p>🏆 الحالة: ${status}</p>
            </div>
        `;

        resultContainer.html(resultHtml);
    }
});
