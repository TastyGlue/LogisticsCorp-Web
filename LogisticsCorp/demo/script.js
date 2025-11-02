// Sample shipment data
const shipmentsData = {
    1: {
        trackingNumber: 'SHP-2024-001',
        weight: '5.2 kg',
        price: '$45.00',
        deliveryType: 'Home Delivery',
        sender: 'Alice Johnson',
        recipient: 'Bob Smith',
        originOffice: 'Downtown Branch',
        destination: '123 Main St, Springfield',
        registeredOn: '2024-01-15 10:30 AM',
        pickedUpOn: '2024-01-15 02:15 PM',
        deliveredOn: '2024-01-16 11:45 AM',
        courier: 'Mike Wilson',
        description: 'Electronic components and accessories - Handle with care',
        status: 'Delivered',
        history: [
            {
                status: 'Delivered',
                date: 'Jan 16, 2024 - 11:45 AM',
                location: '123 Main St, Springfield',
                notes: 'Package successfully delivered to recipient. Signature obtained.',
                employee: 'Mike Wilson'
            },
            {
                status: 'In Transit',
                date: 'Jan 15, 2024 - 02:15 PM',
                location: 'Downtown Distribution Center',
                notes: 'Package picked up and en route to destination.',
                employee: 'Mike Wilson'
            },
            {
                status: 'Registered',
                date: 'Jan 15, 2024 - 10:30 AM',
                location: 'Downtown Branch',
                notes: 'Shipment registered and ready for pickup.',
                employee: 'Sarah Davis'
            }
        ]
    },
    2: {
        trackingNumber: 'SHP-2024-002',
        weight: '0.5 kg',
        price: '$15.00',
        deliveryType: 'Office Pickup',
        sender: 'Tech Corp Inc.',
        recipient: 'Jane Williams',
        originOffice: 'North Branch',
        destination: 'East Side Office',
        registeredOn: '2024-01-18 09:00 AM',
        pickedUpOn: '2024-01-18 11:30 AM',
        deliveredOn: '2024-01-18 03:20 PM',
        courier: 'David Martinez',
        description: 'Important legal documents - Time sensitive',
        status: 'Delivered',
        history: [
            {
                status: 'Delivered',
                date: 'Jan 18, 2024 - 03:20 PM',
                location: 'East Side Office',
                notes: 'Documents delivered to office reception.',
                employee: 'David Martinez'
            },
            {
                status: 'In Transit',
                date: 'Jan 18, 2024 - 11:30 AM',
                location: 'Central Hub',
                notes: 'Package in transit to destination office.',
                employee: 'David Martinez'
            },
            {
                status: 'Registered',
                date: 'Jan 18, 2024 - 09:00 AM',
                location: 'North Branch',
                notes: 'Documents registered for urgent delivery.',
                employee: 'Lisa Anderson'
            }
        ]
    },
    3: {
        trackingNumber: 'SHP-2024-003',
        weight: '12.8 kg',
        price: '$85.00',
        deliveryType: 'Home Delivery',
        sender: 'Antique Gallery',
        recipient: 'Robert Chen',
        originOffice: 'West Branch',
        destination: '456 Oak Avenue, Riverside',
        registeredOn: '2024-01-20 08:15 AM',
        pickedUpOn: '2024-01-20 01:45 PM',
        deliveredOn: null,
        courier: 'Emma Thompson',
        description: 'Fragile antique glassware - Extreme care required',
        status: 'In Transit',
        history: [
            {
                status: 'In Transit',
                date: 'Jan 20, 2024 - 01:45 PM',
                location: 'Highway Distribution Point',
                notes: 'Package carefully loaded. En route to destination with special handling.',
                employee: 'Emma Thompson'
            },
            {
                status: 'Registered',
                date: 'Jan 20, 2024 - 08:15 AM',
                location: 'West Branch',
                notes: 'Fragile items registered. Special handling instructions noted.',
                employee: 'Tom Baker'
            }
        ]
    }
};

// Get DOM elements
const shipmentSelect = document.getElementById('shipment-select');
const trackingNumber = document.getElementById('tracking-number');
const weight = document.getElementById('weight');
const price = document.getElementById('price');
const deliveryType = document.getElementById('delivery-type');
const sender = document.getElementById('sender');
const recipient = document.getElementById('recipient');
const originOffice = document.getElementById('origin-office');
const destination = document.getElementById('destination');
const registeredOn = document.getElementById('registered-on');
const pickedUpOn = document.getElementById('picked-up-on');
const deliveredOn = document.getElementById('delivered-on');
const courier = document.getElementById('courier');
const description = document.getElementById('description');
const timeline = document.getElementById('timeline');

// Status badge element
const statusBadge = document.querySelector('.status-badge');

// Function to get status class
function getStatusClass(status) {
    const statusMap = {
        'Registered': 'status-registered',
        'In Transit': 'status-in-transit',
        'Delivered': 'status-delivered',
        'Cancelled': 'status-cancelled'
    };
    return statusMap[status] || 'status-registered';
}

// Function to update shipment details
function updateShipmentDetails(shipmentId) {
    const shipment = shipmentsData[shipmentId];

    if (!shipment) return;

    // Update basic details
    trackingNumber.textContent = shipment.trackingNumber;
    weight.textContent = shipment.weight;
    price.textContent = shipment.price;
    deliveryType.textContent = shipment.deliveryType;
    sender.textContent = shipment.sender;
    recipient.textContent = shipment.recipient;
    originOffice.textContent = shipment.originOffice;
    destination.textContent = shipment.destination;
    registeredOn.textContent = shipment.registeredOn;
    pickedUpOn.textContent = shipment.pickedUpOn || 'Pending';
    deliveredOn.textContent = shipment.deliveredOn || 'Pending';
    courier.textContent = shipment.courier || 'Not assigned';
    description.textContent = shipment.description;

    // Update status badge
    statusBadge.textContent = shipment.status;
    statusBadge.className = 'status-badge ' + getStatusClass(shipment.status);

    // Update timeline
    updateTimeline(shipment.history);

    // Add subtle animation
    animateUpdate();
}

// Function to update timeline
function updateTimeline(history) {
    timeline.innerHTML = '';

    history.forEach(item => {
        const timelineItem = document.createElement('div');
        timelineItem.className = 'timeline-item';

        timelineItem.innerHTML = `
            <div class="timeline-marker"></div>
            <div class="timeline-content">
                <div class="timeline-header">
                    <span class="timeline-status ${getStatusClass(item.status)}">${item.status}</span>
                    <span class="timeline-date">${item.date}</span>
                </div>
                <div class="timeline-location">${item.location}</div>
                <div class="timeline-notes">${item.notes}</div>
                <div class="timeline-employee">Handled by: ${item.employee}</div>
            </div>
        `;

        timeline.appendChild(timelineItem);
    });
}

// Function to animate updates
function animateUpdate() {
    const cards = document.querySelectorAll('.shipment-details-card, .timeline-card');

    cards.forEach(card => {
        card.style.opacity = '0.7';
        card.style.transform = 'scale(0.98)';

        setTimeout(() => {
            card.style.transition = 'all 0.3s ease';
            card.style.opacity = '1';
            card.style.transform = 'scale(1)';
        }, 50);
    });
}

// Event listener for shipment selection change
shipmentSelect.addEventListener('change', (e) => {
    const selectedShipmentId = e.target.value;
    updateShipmentDetails(selectedShipmentId);
});

// Mobile menu toggle functionality
const hamburgerMenu = document.getElementById('hamburger-menu');
const sidebar = document.getElementById('sidebar');

if (hamburgerMenu && sidebar) {
    hamburgerMenu.addEventListener('click', () => {
        hamburgerMenu.classList.toggle('active');
        sidebar.classList.toggle('open');
    });

    // Close menu when clicking outside
    document.addEventListener('click', (e) => {
        if (window.innerWidth <= 480) {
            if (!sidebar.contains(e.target) && !hamburgerMenu.contains(e.target)) {
                sidebar.classList.remove('open');
                hamburgerMenu.classList.remove('active');
            }
        }
    });

    // Close menu when clicking a nav item on mobile
    document.querySelectorAll('.nav-item').forEach(item => {
        item.addEventListener('click', () => {
            if (window.innerWidth <= 480) {
                sidebar.classList.remove('open');
                hamburgerMenu.classList.remove('active');
            }
        });
    });
}

// Add hover effects to nav items
document.querySelectorAll('.nav-item').forEach(item => {
    item.addEventListener('click', (e) => {
        e.preventDefault();

        // Remove active class from all items
        document.querySelectorAll('.nav-item').forEach(navItem => {
            navItem.classList.remove('active');
        });

        // Add active class to clicked item
        item.classList.add('active');
    });
});

// Add smooth scrolling
document.addEventListener('DOMContentLoaded', () => {
    // Initialize with first shipment
    updateShipmentDetails(1);

    // Add focus effects to select
    // shipmentSelect.addEventListener('focus', () => {
    //     shipmentSelect.parentElement.style.borderColor = 'var(--primary-yellow)';
    // });

    // shipmentSelect.addEventListener('blur', () => {
    //     shipmentSelect.parentElement.style.borderColor = 'var(--border-color)';
    // });
});

// Add keyboard navigation
document.addEventListener('keydown', (e) => {
    if (e.key === 'ArrowLeft' || e.key === 'ArrowRight') {
        const currentValue = parseInt(shipmentSelect.value);
        const options = Array.from(shipmentSelect.options).map(opt => parseInt(opt.value));
        const currentIndex = options.indexOf(currentValue);

        if (e.key === 'ArrowRight' && currentIndex < options.length - 1) {
            shipmentSelect.value = options[currentIndex + 1];
            updateShipmentDetails(options[currentIndex + 1]);
        } else if (e.key === 'ArrowLeft' && currentIndex > 0) {
            shipmentSelect.value = options[currentIndex - 1];
            updateShipmentDetails(options[currentIndex - 1]);
        }
    }
});
