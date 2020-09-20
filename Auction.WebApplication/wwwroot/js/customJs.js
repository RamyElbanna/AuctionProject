// self calling method is required for security
$(function () {
    let auctionComponents = $('#auctionTransactionsComponents');
    let bidderSelected;
    let currentBid;
    let startingPrice;
    let counter = 1;
    let winnerName;
    let itemSelected;
    auctionComponents.css('display', 'none');
    // show auction transaction when the item is selected
    $('#allItems').change(() => {
        // reset auction before change the item
        resetAuction();
        auctionComponents.css('display', 'block');
        let valueSelected = $('#allItems').val();
        let selected = $(`#allItems option[value=${valueSelected}]`).text();
        $('#selectedItem').val(selected);
        currentBid = startingPrice = +(selected.split('-')[1]); // converting it to number;
        itemSelected = selected.split('-')[0];
    });

    $('#biddersinAction').change(() => {
        let valueSelected = $('#biddersinAction').val();
        let selected = $(`#biddersinAction option[value=${valueSelected}]`).text();
        bidderSelected = selected;
    });

    // begin to auction transaction
    $('#bidButton').click(() => {
        let bidValue = $('#bidValue').val();
        let currentBidObj = {
            BiddersTextSelected: bidderSelected,
            bidValue: bidValue
        };
        if (!checkIfCanBid(currentBidObj)) return false;
        beginTransaction(currentBidObj)

    });

    function beginTransaction(bidObject) {
        currentBid = +bidObject.bidValue;
        const bidRow = `<tr>
                            <td>${counter++}</td>
                            <td>${bidObject.BiddersTextSelected}</td>
                            <td>${bidObject.bidValue}$</td>
                            <td>${currentBid - startingPrice}</td>
                        </tr>`;
        $('#transactionBody').append(bidRow);
        winnerName = bidObject.BiddersTextSelected;
    }

    function resetAuction() {
        $('#transactionBody').html('');
        $('#biddersinAction').val('');
        $('#bidValue').val('');
        $('#auctionWinnerContainer').val('');
        $('#auctionWinnerContainer').addClass('d-none');
        $('#saveAuctionBtn').removeAttr('disabled');
        winnerName = undefined;
        counter = 1;
        currentBid = startingPrice;
    }

    function checkIfCanBid(bidObject) {
        if ($('#biddersinAction').val() === null) return false;
        if ($('#bidValue').val() === '') return false;
        if (bidObject.bidValue <= currentBid) return false;
        return true;
    }

    // add new item

    $('#addItemBtn').click(() => {
        let itemStartingPrice = $('#itemStartingPrice').val();
        let itemName = $('#itemName').val();
        if (itemName === '' || itemStartingPrice === '') return false;
        // send object to server
        $.ajax({
            method: 'post',
            data: { itemName: itemName, itemStartingPrice: itemStartingPrice },
            url: '/addItem',
            success: function (result) {
                $('#allItems').append(
                    `<option value=${result.itemId}>${result.itemName} - ${itemStartingPrice}</option>`
                );
                $('#itemName').val('');
                $('#itemStartingPrice').val('');
            }
        })
    })

    // add new bidder

    $('#addBidderBtn').click(() => {
        let bidderName = $('#bidderName').val();
        if (bidderName === '') return false;
        // send object to server
        $.ajax({
            method: 'post',
            data: { bidderName: bidderName},
            url: '/addBidder',
            success: function (result) {
                $('#allBidders, #biddersinAction').append(
                    `<option value=${result.bidderId}>${result.bidderName}</option>`
                );
                $('#bidderName').val('');
            }
        })
    })

    // get the winner details then send to the server
    $('#saveAuctionBtn').click(() => {
        if (winnerName === undefined) return false;

        winnerDetails = `Winner:${winnerName},Price:${currentBid}USD`;
        let winnerContainer = $('#auctionWinnerContainer');
        winnerContainer.removeClass('d-none');
        winnerContainer.val(winnerDetails);
        saveAuction({ winnerName: winnerName, pricePaid: currentBid });
    })

    // send auction details to server
    function saveAuction(winnerDetails) {
        winnerDetails.itemName = itemSelected;
        winnerDetails.startingPrice = startingPrice;
        winnerDetails.profit = winnerDetails.pricePaid - startingPrice;
        $.ajax({
            method: 'post',
            data: winnerDetails,
            url: '/saveAuctionWinnerDetails',
            success: function (result) {
                if (result.success === true)
                    alert('saved successfully');
                else
                    alert('something went wrong');
                $('#saveAuctionBtn').attr('disabled', 'disabled');
            }
        })
    }

}())