const container = document.body;

const observer = new MutationObserver((mutations) => {
  mutations.forEach((mutation) => {
    mutation.addedNodes.forEach((node) => {
      if (node instanceof HTMLElement && node.id === "facebox_overlay") {
        addPopupCopyButton();
      }
    });
  });
});

const config = { childList: true };
observer.observe(container, config);


function addPopupCopyButton() {
  const submissionTests = document.body.getElementsByClassName("test-for-popup");
  if (submissionTests) {
    for (let submissionElement of submissionTests) {
      const testHeader = submissionElement.getElementsByClassName("test-header")[0];
      if (testHeader) {
        const button = createButton(submissionElement);
        testHeader.appendChild(button);
      }
    }

    function createButton(parentElement) {
      const button = document.createElement("div");
      button.className = "protocol-popup-input-output-copier";
      button.textContent = "Copy test case";
      button.onclick = function (e) {
        createAndCopyTests(parentElement);
      };
      return button;
    }

    function prepareText(s) {
        return s.replace(/(.*)\s+$/, '$1') // Remove line breaks and spaces at the end of the text.
    }

    function createAndCopyTests(parentElement) {
        const testNumberElement = parentElement.getElementsByClassName("test")[0];
        const inputElement = parentElement.getElementsByClassName("input")[0];
        const answerElement = parentElement.getElementsByClassName("answer")[0];
        const testNumber = testNumberElement.innerText;
        const input = prepareText(inputElement.innerText);
        const answer = prepareText(answerElement.innerText);
        const testMethod =
                `[Test]
      public void Case${testNumber}()
      {
        var result = GetResult(@"${input}");
        result.Should().Be(@"${answer}");
      }`;

        navigator.clipboard.writeText(testMethod).then(function () {
            console.info("The test case copied to the clipboard");
        });
    }
  }
}
